using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.PurchaseOrderModule
{
    public class PurchaseItem : IPurchaseItem
    {
        public decimal Quantity { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
     }
}
