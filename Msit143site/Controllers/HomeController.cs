using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Msit143site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Msit143site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult First()
        {
            return View();
        }

        public IActionResult Index()
        {
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

        public IActionResult getdemo() {
            return View();
        }

        public IActionResult ajaxevent()
        {
            return View();
        }

        public IActionResult Register() {
            return View();
        }

        public IActionResult Address()
        {
            return View();
        }

        public IActionResult Promise()
        {
            return View();
        }

        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult History() {
            return View();
        }

        public IActionResult AutoComplete()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult Partial()
        {
            return PartialView();
        }

        public IActionResult ShipperCors()
        {
            return View();
        }
    }
}
