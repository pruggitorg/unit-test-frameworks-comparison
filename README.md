# Comparing Unit Testing Frameworks with Examples of Use
This project compares MS Test, NUnit, XUnit and Fluent frameworks. Using an example application, various test scenarios are run through and their implementation in the frameworks is shown.

# At a Glance
## Comparison of basic Assert statements
## Checking with unit tests, if events are fired
## Ensure exceptions are thrown
## Ignoring tests (with attributes and programmatically by extending each unit test framework

```csharp
   [TestFixture]
    public class IgnoreTests
    {
        [Test, Ignore("This test is ignored on purpose")]
        public void IgnoreThisTest()
        {            
            // you will see this test reported as "skipped" in the test run results
        }

        [Test]
        public void IgnoreThisTestWithInconclusive()
        {
            // you will see this test reported as "not run" in the test run results
            Assert.Inconclusive("This test will not run.");
        }

        [Test, IgnoreOn64BitPlatform]
        public void IgnoreWithCustromAttribute()
        {
            // ignored with custom attribute
        }
    }

    /// <summary>
    /// NUnit 3 implements a great deal of its functionality in its Custom Attributes. This functionality is 
    /// accessed through a number of standard interfaces, which are implemented by the attributes. 
    /// Users may create their own attributes by implementing these interfaces.
    /// </summary>
    /// <remarks>Note: Action Attributes are a feature of NUnit V2, designed to better enable composability of test logic. 
    /// They are carried over to NUnit 3, but are not the recommended approach for most new work.</remarks>
    public sealed class IgnoreOn64BitPlatform : NUnitAttribute, IApplyToTest
    {
        public void ApplyToTest(Test test)
        {
            if (Environment.Is64BitOperatingSystem)
                test.RunState = RunState.Ignored;
        }
    }
```    
    
