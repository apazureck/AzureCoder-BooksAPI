using System;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using BooksAPI.OData.Models;

namespace BooksAPI
{
    public class BooksModelBuilder
    {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Book>(nameof(Book))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select();// Allow for the $select Command; 

            builder.EntitySet<Author>(nameof(Author))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select()
                            .ContainsMany(x => x.Books)
                            .Expand(); // Allow for the $select Command

            builder.EntitySet<Publisher>(nameof(Publisher))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select()
                            .HasMany(x => x.Books)
                            .Expand(); // Allow for the $select Command

            return builder.GetEdmModel();
        }
    }
}
