using System.Linq;
using BooksAPI.OData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.OData.Controllers
{
    [Produces("application/json")]
    public class AuthorController : ODataController
    {
        private readonly BooksContext context;

        public AuthorController(BooksContext context) => this.context = context;

        // GET: odata/Author
        [EnableQuery]
        public IQueryable<Author> Get() => context.Authors.AsQueryable();
    }
}