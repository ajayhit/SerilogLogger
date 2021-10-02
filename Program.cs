using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using SerilogLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serilog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
          // add console as logging target
          // add a logging target for warnings and higher severity  logs
          // structured in JSON format
          .WriteTo.File(new JsonFormatter(),
                        "important.json",
                        restrictedToMinimumLevel: LogEventLevel.Warning)
          // add a rolling file for all logs
          .WriteTo.File("all-.logs",
                        rollingInterval: RollingInterval.Day)
          // set default minimum level
          .MinimumLevel.Debug()
          .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
