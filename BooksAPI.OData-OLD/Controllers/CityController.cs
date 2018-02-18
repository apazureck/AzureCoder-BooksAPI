using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OData.Locations.Models;

namespace OData.Locations.Controllers
{
    [Produces("application/json")]
    public class CityController : Controller
    {
        private readonly LocationsContext context;

        public CityController(LocationsContext context) => this.context = context;

        // GET: odata/City
        [EnableQuery]
        public IQueryable<City> Get() => context.Cities.AsQueryable();
    }
}