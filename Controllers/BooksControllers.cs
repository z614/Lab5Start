using System;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        [Route("")] //handles the rough '/books'
        [Route("index")] //handles the route '/books/index'
        public IActionResult Books()
        {
            return View();
        }
        [Route("new")]
        public IActionResult New()
        {
            return View();
        }
        [Route("best-sellers")]
        public IActionResult BestSellers()
        {
            return View();
        }
    }
}