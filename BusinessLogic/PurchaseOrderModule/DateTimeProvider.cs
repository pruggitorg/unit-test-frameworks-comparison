using BusinessLogic.Environment;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.PurchaseOrderModule
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => DateTime.Today;

        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
