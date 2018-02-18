using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OData.Locations.Models;

namespace OData.Locations.Controllers
{
    [Produces("application/json")]
    public class CountryController : Controller
    {
        private readonly LocationsContext context;

        public CountryController(LocationsContext context) => this.context = context;

        // GET: odata/Country
        [EnableQuery]
        public IQueryable<Country> Get() => context.Countries.AsQueryable();
    }
}