using BusinessLogic.PurchaseOrderModule;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.Exceptions
{
    public class ExceptionExamples
    {
        [Test]
        public void Given_Null_For_DatenTimeProvier_Should_Throw_Exception()
        {
            TestDelegate act = () => new PurchaseOrder(null, null);

            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
