using BusinessLogic.Interfaces;
using BusinessLogic.PurchaseOrderModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFunctionality.TestHelper
{
    /// <remarks>Could also implement IPurchaseItem, instead of an extension method</remarks>
    public static class PurchaseItemsHelper
    {
        private static readonly Random _rnd = new Random();

        /// <summary>
        /// Creates a PurchaseItem with random values.
        /// </summary>
        /// <param name="purchaseItem"></param>
        /// <returns></returns>
        public static PurchaseItem CreateRandom(this PurchaseItem purchaseItem)
        {
            decimal quantity = _rnd.Next(1,999);
            decimal price = (decimal)_rnd.Next(0,99); // TODO: create random numbers with commas            

            purchaseItem.ItemId = Guid.NewGuid().ToString();
            purchaseItem.ItemName = String.Format($"Random item {quantity}-{price}");
            purchaseItem.Price = price;
            purchaseItem.Quantity = quantity;

            return purchaseItem;
        }
    }
}
