using BusinessLogic.PurchaseOrderModule;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Serilog;
using Serilog.Extensions.Logging;
using System;

namespace SharedForTests.Logging
{
    public static class LoggingFactory
    {
        /// <summary>
        /// Uses Serilog Debug Logger.
        /// </summary>
        /// <returns></returns>
        /// <remarks>https://benfoster.io/blog/serilog-best-practices/</remarks>
        public static Microsoft.Extensions.Logging.ILogger UseSerilogToDebug()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog
                    (
                        Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Debug
                                (
                                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}"
                                )
                            .CreateLogger()
                    );
            });

            Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger(nameof(PurchaseOrder));

            return logger;
        }

        /// <summary>
        /// Uses Microsoft Console Logger.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Microsoft logger is a logging abstraction, the default sinks are very extremely basic and usually farm out 
        /// to other systems to get more features. Output timestamp by default https://github.com/aspnet/Logging/issues/483#issuecomment-320574792
        /// </remarks>
        public static Microsoft.Extensions.Logging.ILogger UseConsoleLogger()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(configure => configure.TimestampFormat = "MM/dd/yyyy hh:mm:ss.fff tt");
                builder.AddFilter<ConsoleLoggerProvider>(null, LogLevel.Information);
            });

            Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger(nameof(PurchaseOrder));

            return logger;
        }

        [Obsolete("Use UseSerilogToDebug instead.")]
        public static Microsoft.Extensions.Logging.ILogger UseSerilogToDebugWithSerilogLoggerFactory()
        {
            ILoggerFactory loggerFactory = new SerilogLoggerFactory().AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Debug
                    (
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}"
                    )
                .CreateLogger();

            Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger(nameof(PurchaseOrder));

            return logger;
        }
    }
}
