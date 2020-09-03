using BusinessLogic.PurchaseOrderModule;
using NUnit.Framework;
using SharedForTests.PurchaseOrderModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.Events
{
    public class EventExamples : AssertExamplesBase
    {
        [Test]
        public void Adding_Item_Should_Raise_Event()
        {
            // arrange
            PurchaseItem purchaseItem = new PurchaseItem().CreateRandom();

            bool wasRaised = false;
            _purchaseOrder.ItemAdded += (_, s) => { wasRaised = true; };

            // act
            _purchaseOrder.AddPurchaseItem(purchaseItem);

            // assert
            Assert.IsTrue(wasRaised);
        }
    }
}
