using BusinessLogic.PurchaseOrderModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFunctionality.Exceptions
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ExceptionExamples
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_Given_Null_For_DatenTimeProvier_Should_Throw_Exception_V1()
        {
            // act
            PurchaseOrder purchaseOrder = new PurchaseOrder(null, null);
        }
        
        [TestMethod]
        public void MSTest_Given_Null_For_DatenTimeProvier_Should_Throw_Exception_V2()
        {
            // act
            Action act = () => new PurchaseOrder(null, null);

            // assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<ArgumentNullException>(act);
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

