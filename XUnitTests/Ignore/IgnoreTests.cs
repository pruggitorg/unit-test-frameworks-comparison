using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests.Ignore
{
    public class IgnoreTests
    {
        [Fact(Skip = "This test is ignored on purpose")]
        public void IgnoreThisTest()
        {
            // you will see this test reported as "skipped" in the test run results
        }

        [FactIgnoreOn64BitPlatform]
        public void IgnoreWithAttribute()
        {
            // test can be skipped programmatically using FactAttribute
        }
    }

    public sealed class FactIgnoreOn64BitPlatform : FactAttribute
    {
        public FactIgnoreOn64BitPlatform()
        {
            if (Environment.Is64BitOperatingSystem)
                Skip = $"cannot run on 64 bit platforms";
        }
    }
}
