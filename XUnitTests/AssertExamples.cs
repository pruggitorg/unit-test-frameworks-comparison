using BusinessLogic.PurchaseOrderModule;
using Microsoft.Extensions.Logging;
using SharedForTests.Logging;
using System;
using Xunit;

namespace XUnitTests
{

    /// <summary>
    /// Constructor and Dispose: When to use: when you want a clean test context for every test (sharing the setup and cleanup code, without sharing the object instance). 
    /// </summary>
    /// <remarks>
    ///  xUnit.net creates a new instance of the test class for every test that is run, so any code which is placed into the constructor of
    ///  the test class will be run for every single test. This makes the constructor a convenient place to put reusable context setup code where you want 
    ///  to share the code without sharing object instances (meaning, you get a clean copy of the context object(s) for every test that is run).
    ///  For context cleanup, add the IDisposable interface to your test class, and put the cleanup code in the Dispose() method
    /// </remarks>
    public class AssertExamplesBase : IDisposable
    {
        protected PurchaseOrder _purchaseOrder;

        /// <summary>
        /// Test initialize
        /// </summary>
        public AssertExamplesBase()
        {
            ILogger<PurchaseOrder> logger = LoggingFactory.UseSerilogToDebug<PurchaseOrder>();
            _purchaseOrder = new PurchaseOrderFactory().CreatePurchaseOrderInstance(logger);
        }

        /// <summary>
        /// Test cleanup
        /// </summary>
        /// <remarks>https://www.codeproject.com/Articles/29534/IDisposable-What-Your-Mother-Never-Told-You-About</remarks>
        public void Dispose()
        {
            // NOP            
        }
    }

    public class AssertExamples : AssertExamplesBase
    {
        [Fact]
        public void EnsureDateCreatedUsesUTC()
        {
            Assert.Equal(DateTimeKind.Utc, _purchaseOrder.DateCreatedUTC.Kind);
        }

        [Fact]
        public void EnsureNonEmptyGuid()
        {
            Assert.NotEqual(Guid.Empty, _purchaseOrder.Id);
        }
    }
}