using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace BusinessLogic.PurchaseOrderModule
{
    public class PurchaseOrderFactory
    {
        /// <summary>
        /// Creates a new instance of PurchaseOrder
        /// </summary>
        /// <returns></returns>
        public PurchaseOrder CreatePurchaseOrderInstance()
        {            
            ILogger logger = NullLogger.Instance;

            return CreatePurchaseOrderInstance(logger);
        }

        /// <summary>
        /// Creates a new instance of PurchaseOrder
        /// </summary>
        /// <param name="logger">Type used to perfrom logging</param>
        /// <returns></returns>
        public PurchaseOrder CreatePurchaseOrderInstance(ILogger logger)
        {
            IDateTimeProvider dateTimeProvider = new DateTimeProvider();

            return new PurchaseOrder(dateTimeProvider, logger);
        }
    }
}
