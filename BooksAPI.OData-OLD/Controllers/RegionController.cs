using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OData.Locations.Models;

namespace OData.Locations.Controllers
{
    [Produces("application/json")]
    public class RegionController : Controller
    {
        private readonly LocationsContext context;

        public RegionController(LocationsContext context) => this.context = context;

        // GET: odata/Region
        [EnableQuery]
        public IQueryable<Region> Get() => context.Regions.AsQueryable();
    }
}