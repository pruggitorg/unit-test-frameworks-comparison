using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MSTestAndFluentTests.Ignore
{
    [TestClass]
    public class IgnoreTests
    {
        [TestMethod, Ignore("This test ignored on purpose.")]
        public void IgnoreThisTest()
        {
            // this test is never executed
            // it is recommended to indicate why it's ignored
        }

        [TestMethod]
        public void IgnoreThisTestWithInconclusive()
        {
            Assert.Inconclusive("This test ignored on purpose.");
        }

        [IgnoreOn64BitPlatform]
        public void IgnoreWithCustromAttribute()
        {
            // ignored with custom attribute
        }
    }

    /// <summary>
    /// The default workflow for running tests in MSTest V2 involves creating an instance of a 
    /// TestClass and invoking a TestMethod in it. There are multiple instances where this workflow is 
    /// required to be tweaked so specific tests are runnable. Some tests require to be run on a UI Thread, 
    /// some others need to be parameterized.
    /// Using TestMethodAttribute allows you to extend MSTest.
    /// </summary>
    public sealed class IgnoreOn64BitPlatformAttribute : TestMethodAttribute
    {
        public IgnoreOn64BitPlatformAttribute()
        { }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            List<TestResult> testResults = new List<TestResult>();
            testResults.Add(
                new TestResult() { Outcome = UnitTestOutcome.Inconclusive, 
                                   TestFailureException = new AssertInconclusiveException("cannot run on 64 bit platforms") }
                );
            return testResults.ToArray();
        }
    }
}
