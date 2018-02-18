using System.Collections.Generic;
using BooksAPI.REST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.REST.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly BooksContext context;

        public BooksController(BooksContext context) => this.context = context;

        // GET: api/books
        [HttpGet]
        public IEnumerable<Book> Get() => context.Books.Include(b => b.Author).Include(b => b.Publisher);
    }
}