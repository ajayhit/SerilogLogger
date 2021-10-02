using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Models;
using SerilogLogger.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Serilog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int a,int b)
        {
            // logging
            try
            {
                var c = a / b;
                Log.Verbose("Some verbose log");
                Log.Debug("Some debug log");
                Log.Information("Output {@c} ", c);
                Log.Warning("Warning accrued at {now}", DateTime.Now);
               
            }
            catch (Exception ex)
            {
                Log.Error("Error accrued at {now}",ex.Message, DateTime.Now);
                Log.Fatal("Error Name ",ex.Message,  DateTime.Now);
            }



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
