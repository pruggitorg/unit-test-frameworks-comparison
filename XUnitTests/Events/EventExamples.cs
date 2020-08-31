using BusinessLogic.PurchaseOrderModule;
using SharedForTests.PurchaseOrderModule;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests.Events
{
    public class EventExamples : AssertExamplesBase
    {
        [Fact]
        public void Adding_Item_Should_Raise_Event()
        {
            // arrange
            PurchaseItem purchaseItem = new PurchaseItem().CreateRandom();

            // act
            Action act = () => _purchaseOrder.AddPurchaseItem(purchaseItem);

            // assert
            Assert.Raises<ItemAddedEventArgs>(handler => _purchaseOrder.ItemAdded += handler,
                                              handler => _purchaseOrder.ItemAdded -= handler,
                                              act);
        }
    }
}
