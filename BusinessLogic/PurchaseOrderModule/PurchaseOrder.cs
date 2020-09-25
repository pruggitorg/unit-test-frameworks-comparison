using BusinessLogic.Environment;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.PurchaseOrderModule
{    
    public class PurchaseOrder
    {
        private Guid _id;
        private DateTime _dateCreated;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILogger<PurchaseOrder> _logger;        
        private List<IPurchaseItem> _purchaseItems;

        public Guid Id { get => _id; private set => _id = value; }

        /// <summary>
        /// Date of order's creation using UTC format
        /// </summary>
        public DateTime DateCreatedUTC { get => _dateCreated; private set => _dateCreated = value; }

        /// <summary>
        /// Returns the total amount of the purchase order.
        /// </summary>
        public decimal TotalAmount { get => CalcOrderTotalAmount(); }

        public delegate void EventHandler(object sender, ItemAddedEventArgs e);
        public event EventHandler<ItemAddedEventArgs> ItemAdded;

        /// <summary>
        /// Creates a new instance of the purchase order with custom date-time provider.
        /// </summary>
        /// <param name="dateTimeProvider">Provider for the date and time</param>
        /// <param name="logger"></param>
        /// <param name="item">Type representing the purchase item</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>https://stackoverflow.com/questions/51345161/should-i-take-ilogger-iloggert-iloggerfactory-or-iloggerprovider-for-a-libra</remarks>
        public PurchaseOrder(IDateTimeProvider dateTimeProvider, ILogger<PurchaseOrder> logger)
        {
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException("DateTimeProvider must not be null.");
            _logger = logger ?? throw new ArgumentNullException("Logger must not be null.");

            _logger.LogTrace($"{nameof(PurchaseOrder)} ctor");

            _purchaseItems = new List<IPurchaseItem>();

            SetOrderDefaultValues();
        }

        public void AddPurchaseItem(IPurchaseItem item)
        {
            _purchaseItems.Add(item);
            RaiseItemAdded(new ItemAddedEventArgs() { ItemAdded = item }) ;

            _logger.LogTrace("{nameOfMethod} {@item}", nameof(AddPurchaseItem), item);
        }

        public IEnumerable<IPurchaseItem> GetPurchaseItems()
        {
            return _purchaseItems;
        }

        private decimal CalcOrderTotalAmount()
        {
            return (_purchaseItems.Sum(x => (x.Price) * (x.Quantity)));
        }

        private void SetOrderDefaultValues()
        {
            _logger.LogTrace(nameof(SetOrderDefaultValues));

            DateCreatedUTC = _dateTimeProvider.UtcNow;
            Id = Guid.NewGuid();            
        }

        protected virtual void RaiseItemAdded(ItemAddedEventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }
    }

    public class ItemAddedEventArgs : EventArgs
    {
        public IPurchaseItem ItemAdded { get; set; }
    }
}
