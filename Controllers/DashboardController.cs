using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingLearning.Controllers
{
    [Route("my")]
    public class DashboardController : Controller
    {
        [Route("main")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
