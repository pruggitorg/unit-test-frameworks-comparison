using BusinessLogic.PurchaseOrderModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreFunctionality.Exceptions
{
    [TestClass]
    public class ExceptionExamples
    {
        /// <summary>
        /// Expecting an exception using an attribute
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Null_For_DatenTimeProvier_Should_Throw_Exception_V1()
        {
            // act
            PurchaseOrder purchaseOrder = new PurchaseOrder(null, null);
        }
        
        [TestMethod]
        public void Given_Null_For_DatenTimeProvier_Should_Throw_Exception_V2()
        {
            // act
            Action act = () => new PurchaseOrder(null, null);

            // assert
            Assert.ThrowsException<ArgumentNullException>(act);
        }


        [TestMethod]
        public void Fluent_Given_Null_For_DatenTimeProvier_Should_Throw_Exception()
        {
            // act
            Action act = () => new PurchaseOrder(null, null);

            // assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}

