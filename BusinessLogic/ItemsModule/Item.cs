using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ItemsModule
{
    public class Item : IItem
    {
        private string _itemId;
        private string _itemName;
        private decimal _price;

        public string ItemId { get => _itemId; set => _itemId = value ?? String.Empty; }
        public string ItemName { get => _itemName; set => _itemName = value ?? String.Empty; }
        public decimal Price { get => _price; set => _price = value; }
    }
}
