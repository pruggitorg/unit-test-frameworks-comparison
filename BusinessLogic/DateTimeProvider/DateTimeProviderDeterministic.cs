using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BusinessLogic.Environment
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>https://stackoverflow.com/a/29431070/6739870</remarks>
    public class DateTimeProviderDeterministic : IDateTimeProvider
    {
        private static readonly ThreadLocal<Func<DateTime>> _getTime =
            new ThreadLocal<Func<DateTime>>(() => () => DateTime.Now);

        /// <inheritdoc cref="DateTime.Today"/>
        public DateTime Today
        {
            get { return _getTime.Value().Date; }
        }

        /// <inheritdoc cref="DateTime.Now"/>
        public DateTime Now
        {
            get { return _getTime.Value(); }
        }

        /// <inheritdoc cref="DateTime.UtcNow"/>
        public DateTime UtcNow
        {
            get { return _getTime.Value().ToUniversalTime(); }
        }

        /// <summary>
        /// Sets a fixed (deterministic) time for the current thread to return by <see cref="SystemClock"/>.
        /// </summary>
        public void Set(DateTime time)
        {
            if (time.Kind != DateTimeKind.Local)
                time = time.ToLocalTime();

            _getTime.Value = () => time;
        }

        /// <summary>
        /// Resets <see cref="SystemClock"/> to return the current <see cref="DateTime.Now"/>.
        /// </summary>
        public void Reset()
        {
            _getTime.Value = () => DateTime.Now;
        }
    }

}
