using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }

        DateTime Now { get; }

        DateTime UtcNow { get; }
    }
}
