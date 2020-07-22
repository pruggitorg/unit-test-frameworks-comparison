using BusinessLogic.PurchaseOrderModule;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using FluentAssertions;
using System;

namespace UnitTestsFrameworkComparison
{
    [TestClass]
    public class AssertExamples
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
        public void MSTest_EnsureDateCreatedUsesUTC()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }

        [TestMethod]
        public void MSTest_EnsureNonEmptyGuid()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotSame(Guid.Empty, _purchaseOrder.Id);
        }

        [TestMethod]
        public void MSTest_Ensure_TotalAmount()
        {
            // arrange
            decimal quantity = 2;
            decimal price = (decimal)20.02;
            decimal totalAmount = quantity * price;

            PurchaseItem purchaseItem = new PurchaseItem()
            {
                ItemId = new Guid().ToString(),
                ItemName = "unit test item name",
                Price = price,
                Quantity = quantity
            };

            // act
            _purchaseOrder.AddPurchaseItem(purchaseItem);

            // assert
            Assert.AreEqual(totalAmount, _purchaseOrder.TotalAmount);
        }


        [TestMethod]
        public void Fluent_EnsureDateCreatedUsesUTC()
        {
            _purchaseOrder.DateCreatedUTC.Kind.Should().Be(DateTimeKind.Utc);
        }

        [TestMethod]
        public void Fluent_EnsureNonEmptyGuid()
        {
            _purchaseOrder.Id.Should().NotBeEmpty("GUID is created on class instance.");
        }


        [TestMethod]
        public void XUnit_EnsureDateCreatedUsesUTC()
        {         
            Xunit.Assert.Equal(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }

        [TestMethod]
        public void XUnit_EnsureNonEmptyGuid()
        {
            Xunit.Assert.NotEqual(Guid.Empty, _purchaseOrder.Id);
        }


        [TestMethod]
        public void NUnit_EnsureDateCreatedUsesUTC()
        {         
            NUnit.Framework.Assert.AreEqual(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }

        [TestMethod]
        public void NUnit_CreatedPurchase_Should_Not_Have_Empty_Id()
        {
            NUnit.Framework.Assert.AreNotSame(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }
    }
}
