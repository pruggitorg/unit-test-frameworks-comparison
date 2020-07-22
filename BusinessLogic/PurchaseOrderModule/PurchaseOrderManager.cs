using BusinessLogic.Environment;
using BusinessLogic.Interfaces;
using BusinessLogic.ItemsModule;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.PurchaseOrderModule
{
    public class PurchaseOrderFactory
    {
        public PurchaseOrder CreatePurchaseOrderInstance()
        {
            IDateTimeProvider dateTimeProvider = new DateTimeProvider();
            ILogger logger = NullLogger.Instance;           

            return new PurchaseOrder(dateTimeProvider, logger);
        }
    }
}
