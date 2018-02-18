using System;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using OData.Locations.Models;

namespace OData.Locations
{
    public class LocationsModelBuilder
    {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EnableLowerCamelCase();

            builder.EntitySet<Country>(nameof(Country))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand(2) // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select();// Allow for the $select Command; 

            builder.EntityType<Country>()
                            .ContainsMany(x => x.Regions)
                            .Expand()
                            .IsExpandable();

            builder.EntityType<Region>()
                            .ContainsMany(x => x.Cities)
                            .Expand()
                            .IsExpandable();

            builder.EntitySet<Region>(nameof(Region))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select()
                            .ContainsMany(x => x.Cities)
                            .Expand(); // Allow for the $select Command

            builder.EntitySet<City>(nameof(City))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select(); // Allow for the $select Command

            return builder.GetEdmModel();
        }
    }
}
