using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msit143site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Msit143site.Controllers
{
    public class ApiController : Controller
    {

        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;
        private readonly NorthwindContext _db;


        public ApiController(IWebHostEnvironment host, DemoContext context, NorthwindContext db)
        {
            _host = host;
            _context = context;
            _db = db;
        }
        public IActionResult Index(string keyword)
        {

            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "ajax";
            }
            //return View();
            return Content($" {keyword}你好", "text/html", System.Text.Encoding.UTF8);
        }


        public IActionResult sleep() {
            System.Threading.Thread.Sleep(5000);
            return Content("hello ajax event", "text/plain");
        }
      
        public IActionResult Register(Member member,IFormFile File1)
        {
            //string info = $"{File1.FileName}-{File1.ContentType}-{File1.Length}";
            //todo 將收到的會員寫入資料庫中
            string filePath = Path.Combine(_host.WebRootPath, "uploads", File1.FileName);
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File1.CopyTo(fileStream);
            }

            byte[] imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                File1.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }

            member.FileName = File1.FileName;
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();
            //string info = _host.WebRootPath;
            //string info = _host.ContentRootPath;
            //return Content(member.Name, "text/plain");
            //return Content(info, "text/plain");
            return Content(filePath, "text/plain");
        }


        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);

        }

        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(sites);

        }

        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);

        }

        public IActionResult CheckAccount(string name)
        {
            var exists = _context.Members.Any(m => m.Name == name);
            return Content(exists.ToString(), "text/plain");
        }

        public IActionResult Products(string keyword)
        {
            var products = _db.Products.Where(p => p.ProductName.Contains(keyword)).Select(p => p.ProductName);
            return Json(products);
        }
    }
}
