using LoggingLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoggingLearning.Services;
using Serilog;

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
            var result = new BusinessTransactionResultViewModel("There some problems on out side, please try to submit your username later!");
            try
            {
                result = businessTransactionService.ProcessSubmit(username);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error with submitted username \"{A}\"", username);
            }

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
