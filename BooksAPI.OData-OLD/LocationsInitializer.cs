using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OData.Locations.Models;

namespace OData.Locations
{
    internal static class LocationsInitializer
    {
        private static bool _initialized = false;
        private static object _lock = new object();
        private static List<City> cities;

        private static List<Country> countries;

        private static List<Region> regions;

        public static void Seed(LocationsContext context)
        {
            AddCountries(context);
            AddRegions(context);
            AddCities(context);
        }

        internal static void Initialize(LocationsContext context)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (_initialized)
                        return;

                    InitializeData(context);
                }
            }
        }

        private static void AddCities(LocationsContext context)
        {
            var nb = context.Regions.Single(r => r.Name == "North Brabant");
            var nh = context.Regions.Single(r => r.Name == "North Holland");
            var sp = context.Regions.Single(r => r.Name == "Sao Paulo");
            var rs = context.Regions.Single(r => r.Name == "Rio Grande do Sul");
            cities = new List<City>
            {
                new City
                {
                    Name = "Breda",
                    Region = nb
                },
                new City
                {
                    Name = "Tilburg",
                    Region = nb
                },
                new City
                {
                    Name = "Amsterdam",
                    Region = nh
                },
                new City
                {
                    Name = "Harleem",
                    Region = nh
                },
                new City
                {
                    Name = "Sao Paulo",
                    Region = sp
                },
                new City
                {
                    Name = "Guarulhos",
                    Region = sp
                },
                new City
                {
                    Name = "Porto Alegre",
                    Region = rs
                },
                new City
                {
                    Name = "Gramado",
                    Region = rs
                }
            };

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }

        private static void AddCountries(LocationsContext context)
        {
            countries = new List<Country>
            {
                new Country
                {
                    Name = "Brazil"
                },
                new Country
                {
                    Name = "Netherlands"
                }
            };
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }
        }

        private static void AddRegions(LocationsContext context)
        {
            var nl = context.Countries.Single(c => c.Name == "Netherlands");
            var br = context.Countries.Single(c => c.Name == "Brazil");
            regions = new List<Region>
            {
                new Region
                {
                    Name = "North Brabant",
                    Country = nl
                },
                new Region
                {
                    Name = "North Holland",
                    Country = nl
                },
                new Region
                {
                    Name = "Sao Paulo",
                    Country = br
                },
                new Region
                {
                    Name = "Rio Grande do Sul",
                    Country = br
                }
            };
            if (!context.Regions.Any())
            {
                context.Regions.AddRange(regions);
                context.SaveChanges();
            }
        }

        private static void InitializeData(LocationsContext context)
        {
            context.Database.Migrate();
            Seed(context);
        }
    }
}