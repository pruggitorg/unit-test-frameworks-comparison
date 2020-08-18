using BusinessLogic.PurchaseOrderModule;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests.Exceptions
{
    public class ExceptionExamples
    {
        [Fact]
        public void Given_Null_For_DatenTimeProvier_Should_Throw_Exception()
        {
            Action act = () => new PurchaseOrder(null, null);

            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
