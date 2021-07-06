using LoggingLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoggingLearning.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
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

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (HttpContext.Request.Path != "/privacy" && !HttpContext.Request.Cookies.ContainsKey("tc-accepted"))
        //    {
        //        filterContext.Result = RedirectToAction("Privacy");
        //    }
        //}

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormModel model)
        {
            //if (!TryValidateModel(model, nameof(FormModel)))
            //{
            //    return View(model);
            //}

            return View(new FormModel());
        }

        [Route("privacy")]
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
