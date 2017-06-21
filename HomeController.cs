using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace loggingTest.Controllers
{
    public class HomeController : Controller
    {
        protected ILoggerFactory LoggerFactory { get; set; }

        public HomeController(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            LogToOutputWindow();
            return View();
        }
        protected void LogToOutputWindow()
        {
            var logger = LoggerFactory
                            .AddDebug(LogLevel.Error)
                            .CreateLogger<HomeController>();

            logger.LogCritical("critical error message...");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
