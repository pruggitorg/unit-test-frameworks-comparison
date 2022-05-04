using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.PurchaseOrderModule
{
    public class PurchaseItem : IPurchaseItem
    {
        private string _itemId;

        public decimal Quantity { get; set; }

        /// <summary>
        /// Unique ID for this item. A GUID is used when trying to set null or white space.
        /// </summary>
        public string ItemId
        {
            get => _itemId;
            set => _itemId = Guard(value);
        }

        public string ItemName { get; set; }
        public decimal Price { get; set; }

        protected virtual string Guard(string value)
        {
            return String.IsNullOrWhiteSpace(value) ? Guid.NewGuid().ToString() : value;
        }
    }
}
