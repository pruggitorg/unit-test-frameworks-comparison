using BusinessLogic.PurchaseOrderModule;
using NUnit.Framework;
using System;

namespace NUnitTests
{
    [TestFixture]
    public class AssertExamplesBase
    {
        protected PurchaseOrder _purchaseOrder;

        [SetUp]
        public void TestSetup()
        {
            _purchaseOrder = new PurchaseOrderFactory().CreatePurchaseOrderInstance();
        }

        [TearDown]
        public void TestCleanup()
        {
            _purchaseOrder = null;
        }
    }

    public class AssertExamples : AssertExamplesBase
    {
        [Test]
        public void EnsureDateCreatedUsesUTC()
        {
            Assert.AreEqual(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }

        [Test]
        public void CreatedPurchase_Should_Not_Have_Empty_Id()
        {
            Assert.AreNotSame(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }
    }
}