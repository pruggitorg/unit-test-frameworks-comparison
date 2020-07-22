using BusinessLogic.PurchaseOrderModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using CoreFunctionality.TestHelper;
using BusinessLogic.Interfaces;

namespace CoreFunctionality.Events
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class EventExamples
    {
        private PurchaseOrder _purchaseOrder;

        [TestInitialize]
        public void TestSetup()
        {
            _purchaseOrder = new PurchaseOrderFactory().CreatePurchaseOrderInstance();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _purchaseOrder = null;
        }

        [TestMethod]
        public void Fluent_Adding_Item_Should_Raise_Event()
        {
            // arrange
            PurchaseItem purchaseItem = new PurchaseItem().CreateRandom(); ;

            // act
            using (var eventSource = _purchaseOrder.Monitor())
            {
                _purchaseOrder.AddPurchaseItem(purchaseItem);

                // assert
                eventSource.Should().Raise("ItemAdded");
            }
        }

        [TestMethod]
        public void NUnit_Adding_Item_Should_Raise_Event()
        {
            // arrange
            PurchaseItem purchaseItem = new PurchaseItem().CreateRandom();
           
            bool wasRaised = false;
            _purchaseOrder.ItemAdded += (_, s) => { wasRaised = true; };

            // act
            _purchaseOrder.AddPurchaseItem(purchaseItem);

            // assert
            NUnit.Framework.Assert.IsTrue(wasRaised);
        }
    }
}

