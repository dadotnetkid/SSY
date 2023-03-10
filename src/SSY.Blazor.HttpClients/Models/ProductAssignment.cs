using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{
    public class ProductAssignment
    {
        public List<Product> Products2 { get; set; } = new();

        public ProductAssignment()
        {

            Product[] products = new Product[] {
                new Product{ Id = 1, ISOName = "Brief" },
                new Product{ Id = 2, ISOName = "Tshirt" },
                new Product { Id = 3, ISOName = "Bra" },
                new Product { Id = 4, ISOName = "Panty" },

            };
            Products2.AddRange(products);
        }
    }
    public class Product
    {
        //https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        //https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population
        //https://www.iso.org/iso-3166-country-codes.html

        public int Id { get; set; }
        public string ISOName { get; set; }

    }
}
