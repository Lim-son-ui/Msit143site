using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msit143site.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return Content("<h2>hello ajax 你好</h2>","text/html",System.Text.Encoding.UTF8);
        }

      

    }
}
