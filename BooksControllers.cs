using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase{
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db = db;
            if (this.db.Books.Count () == 0)
            {
                this.db.Books.Add(new Book()
                {
                    Id = 1,
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    ISBN = "978-02016333610"
                });
                this.db.Books.Add(new Book()
                {
                    Id = 2,
                    Title = "Continous Delivery",
                    Author = "Jez Humble",
                    ISB "978-03-21601919"
                });
                this db.Books.Add(new Book()
                {
                    Id =3,
                    Title = "The DevOps Handbook",
                    Author = "Gene Kim",
                    ISBN = "978-1942788003"
                });
            }
        this.db.SaveChanges();
        }
      [HttpGet]
      public IActionResult Get()
      {
          return Ok(db.Books);
      }
      [HttpGet {"{id}"}]
      public IActionResult GetBook(int id)
      {
          var book = db,Books.FirstOrDefault(book => b.Id == id);

          if (book = null)
          {
              return NotFound();
          }
          return Ok(book);
      }
      [HttpPost]
      public IActionResult Post([FromBody]Book book)
      {
          if (book == null)
          {
              return BadRequest();
          }
          db.Books.Add(book);
          db.SaveChanges();

          return CreatedAtRouteResult("GetBook", new { id = book,Id }, book);
      }
    }
}