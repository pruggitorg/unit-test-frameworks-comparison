using BusinessLogic.PurchaseOrderModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MSTestAndFluentTests.DataDriven
{
    /// <summary>
    /// Demos data driven tests using DataRow attribute
    /// </summary>
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class DataDrivenDataRowsExamples
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

        [DataTestMethod]
        [DataRow("1", "!§$%&/(")]
        [DataRow("2", "/*-+")]
        public void Given_Special_Characters_Expect_Corrent_ItemName(string itemId, string itemName )
        {
            // act
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                ItemId = itemId,
                ItemName = itemName,
                Quantity = 1,
                Price = 1.0M
            };

            // assert
            Assert.AreEqual(itemName, purchaseItem.ItemName);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        [DataRow("     ")]
        public void Given_EmptyNullOrWhiteSpace_ItemId_Expect_Guid(string itemId)
        {
            // arrange

            // act
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                ItemId = itemId,
                ItemName = "Testing item with null or empty values",
                Quantity = 2,
                Price = 123.45M
            };

            // assert
            Assert.IsTrue(Guid.TryParse(purchaseItem.ItemId, out Guid guidResult));
        }

        /// <summary>
        /// Demos that you cannot pass a decimal value in a DataRow attribute. This is a limitation of C# and not
        /// a limitation of the test framework.
        /// 
        /// Cannot compile due to:
        /// An attribute argument must be a constant expression, typeof expression or array 
        /// creation expression of an attribute parameter type. Compiler Error CS0182
        ///         
        /// Instead, <use cref="DataDrivenDynamicDataExamples"/>
        /// </summary>     
        // [DataTestMethod]
        // [DataRow(164.80M)]
        public void Cannot_pass_decimal_value(decimal itemPrice)
        {
            PurchaseItem purchaseItem = new PurchaseItem()
            {
                ItemId = Guid.NewGuid().ToString(),
                ItemName = "Test Item",
                Quantity = 12,
                Price = itemPrice
            };

            Assert.AreEqual(itemPrice, purchaseItem.Price);
        }
    }
}