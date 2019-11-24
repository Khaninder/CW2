using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CW2.Models;
using CW2.APIHandlerManager;
using Newtonsoft.Json;

namespace CW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Books(string category)
        {
            APIHandler webHandler = new APIHandler();
            Rootobject books = webHandler.GetBooks(category);

            return View(books);
        }
        public IActionResult Books_Category()
        {
            APIHandler webHandler = new APIHandler();
            Book_Category booksCategory = webHandler.GetBooksCategory();

            return View(booksCategory);
        }
        public IActionResult Buy_Links(string category)
        {
            APIHandler webHandler = new APIHandler();
            Rootobject books = webHandler.GetBooks(category);

            return View(books);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
