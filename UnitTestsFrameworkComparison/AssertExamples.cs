using BusinessLogic.PurchaseOrderModule;
using System;

namespace UnitTestsFrameworkComparison
{
    namespace UnitTestsFrameworkComparison.Base
    {
        using Microsoft.Extensions.Logging;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using SharedForTests.Logging;

        [TestClass]
        public class AssertExamplesBase
        {
            protected PurchaseOrder _purchaseOrder;

            [TestInitialize]
            public void TestSetup()
            {
                ILogger logger = LoggingFactory.UseSerilogToDebug();
                _purchaseOrder = new PurchaseOrderFactory().CreatePurchaseOrderInstance(logger);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                _purchaseOrder = null;
            }
        }
    }

    namespace UnitTestsFrameworkComparison.MsTest
    {
        using UnitTestsFrameworkComparison.Base;
        using Microsoft.VisualStudio.TestTools.UnitTesting;

        [TestClass]
        public class AssertExamples : AssertExamplesBase
        {
            [TestMethod]
            public void MSTest_EnsureDateCreatedUsesUTC()
            {
                Assert.AreEqual(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
            }

            [TestMethod]
            public void MSTest_EnsureNonEmptyGuid()
            {
                Assert.AreNotSame(Guid.Empty, _purchaseOrder.Id);
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
        }
    }

    namespace UnitTestsFrameworkComparison.Fluent
    {
        using UnitTestsFrameworkComparison.Base;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using FluentAssertions;

        public class AssertExamples : AssertExamplesBase
        {
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
        }
    }
}
