using LoggingLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoggingLearning.Services;

namespace LoggingLearning.Controllers
{
    public class HomeController : Controller
    {
        private IBusinessTransactionService businessTransactionService;

        public HomeController(IBusinessTransactionService businessTransactionService)
        {
            this.businessTransactionService = businessTransactionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            var result = businessTransactionService.ProcessSubmit(username);
            return View(result);
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
