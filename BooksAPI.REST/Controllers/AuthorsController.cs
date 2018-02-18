using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksAPI.REST.Models;

namespace BooksAPI.REST.Controllers
{
    [Produces("application/json")]
    [Route("api/Authors")]
    public class AuthorsController : Controller
    {
        private readonly BooksContext context;

        public AuthorsController(BooksContext context) => this.context = context;

        // GET: api/Authors
        [HttpGet]
        public IEnumerable<Author> Get() => context.Authors.Include(r => r.Books).ThenInclude(b => b.Publisher);
    }
}