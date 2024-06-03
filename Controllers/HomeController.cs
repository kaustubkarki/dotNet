using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using wepAppPractice.Models;
using wepAppPractice.Repository;

namespace wepAppPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDemo _Demo;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IDemo Demo)
        {

            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _Demo = Demo;
        }
        public IActionResult Index()
        {


            var data = _Demo.GetData();
            var model = new HomeModel
            {
                Name = "karki kaustub",
                Age = 21,
                Data = "he lives in kathmandu"
            };

            ViewBag.demo = data;
            ViewBag.life = "Dreams are message from the deep";
            ViewData["Message"] = "Dream makes good stories";
            TempData["order"] = "But things happen when we are awake";
            return View(model);
        }
       
       
        public IActionResult GetSessionData()
        {
            // Retrieve data from session
            string userName = HttpContext.Session.GetString("UserName");
            int? userAge = HttpContext.Session.GetInt32("UserAge");

            ViewBag.UserName = userName;
            ViewBag.UserAge = userAge;

            return View();
        }
        public IActionResult Privacy()
        {
           
            return View();
        }

        public IActionResult RedirectToAnotherAction()
        {
            var data = _Demo.GetData();
            TempData["log"] = "This message is redirection and your dumb head just had an ERROER!!!!(yes the spelling is wrong)";
            return RedirectToAction("Error", "Home");
        }
        public IActionResult GetJsonData()
        {
            //controller ma vako funtion lai Action 
            var data = new { Name = "John", Age = 22 };
            return Json(data);
        }

        public IActionResult PlainText()
        {
            var data = _Demo.GetData();
            return Content("This is a plain text", "application/json");
        }

        public IActionResult DownloadFile()
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "example.txt");
            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "application/pdf", "example.txt");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult ShowPartial()
        { return PartialView("_TestPartial"); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
