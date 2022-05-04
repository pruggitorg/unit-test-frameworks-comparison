using BusinessLogic.PurchaseOrderModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedForTests.PurchaseOrderModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSTestAndFluentTests.DataDriven
{
    /// <summary>
    /// Demos data driven tests using DynamicData attribute
    /// </summary>
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class DataDrivenDynamicDataExamples
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
            // NOP
        }

        /// <summary>
        /// Test using DynamicData for data driven tests. The data source must return IEnumerable<object[]>.
        /// </summary>
        /// <param name="purchaseItem"></param>
        [DataTestMethod]
        [DynamicData(nameof(ItemsTestDataAsMethod), DynamicDataSourceType.Method)]
        public void DynamicDataAsMethod_Adding_Item_Should_Update_TotalAmount(PurchaseItem purchaseItem, decimal exptectedTotalAmount)
        {
            // act
            _purchaseOrder.AddPurchaseItem(purchaseItem);

            // assert
            Assert.AreEqual(exptectedTotalAmount, _purchaseOrder.TotalAmount);
        }

        /// <summary>
        /// Returns items test data via a method.
        /// </summary>
        /// <returns></returns>
        protected static IEnumerable<object[]> ItemsTestDataAsMethod()
        {
            yield return new object[]
                {
                    new PurchaseItem() { ItemId = Guid.NewGuid().ToString(), ItemName = "TestItem 42 from method", Quantity = 10, Price = 64.95M },
                    649.5M
                };

            yield return new object[]
                {
                    new PurchaseItem() { ItemId = Guid.NewGuid().ToString(), ItemName = "TestItem 43 from method", Quantity = 4, Price = 11.01M },
                    44.04M
                };
        }

        /// <summary>
        /// Test using DynamicData for data driven tests. The data source must return IEnumerable<object[]>.
        /// </summary>
        /// <param name="purchaseItem"></param>
        [DataTestMethod]
        [DynamicData(nameof(ItemsTestDataAsProperty), DynamicDataSourceType.Property)]
        public void DynamicDataAsProperty_Adding_Item_Should_Update_TotalAmount(PurchaseItem purchaseItem)
        {
            // act
            _purchaseOrder.AddPurchaseItem(purchaseItem);

            // assert
            Assert.AreEqual(purchaseItem.Price * purchaseItem.Quantity, _purchaseOrder.TotalAmount);
        }

        /// <summary>
        /// Returns items test data via a property.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> ItemsTestDataAsProperty
        {
            get
            {
                yield return new object[]
                    {
                    new PurchaseItem() { ItemId = Guid.NewGuid().ToString(), ItemName = "TestItem 42 from property", Quantity = 10, Price = 64.95M }
                    };

                yield return new object[]
                    {
                    new PurchaseItem() { ItemId = Guid.NewGuid().ToString(), ItemName = "TestItem 43 from property", Quantity = 4, Price = 11.01M }
                    };
            }
        }
    }
}

