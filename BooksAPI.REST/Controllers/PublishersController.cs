using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksAPI.REST.Models;

namespace BooksAPI.REST.Controllers
{
    [Produces("application/json")]
    [Route("api/Publishers")]
    public class PublishersController : Controller
    {
        private readonly BooksContext context;

        public PublishersController(BooksContext context) => this.context = context;

        // GET: api/Publishers
        [HttpGet]
        public IEnumerable<Publisher> Get() => context.Publishers.Include(r => r.Books).ThenInclude(b => b.Author);
    }
}