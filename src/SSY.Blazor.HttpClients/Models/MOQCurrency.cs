using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{
    public class MOQCurrency
    {
        public List<moqcurren> rc2 { get; set; } = new();

        public MOQCurrency()
        {

            moqcurren[] rec = new moqcurren[] {
                new moqcurren{ Id = 1, ISOName = "USD" },
                new moqcurren{ Id = 2, ISOName = "PESO" },
                 new moqcurren{ Id = 3, ISOName = "EURO" },
                  new moqcurren{ Id = 4, ISOName = "POUNDS" },

            };
            rc2.AddRange(rec);
        }
    }
    public class moqcurren
    {
        //https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        //https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population
        //https://www.iso.org/iso-3166-country-codes.html

        public int Id { get; set; }
        public string ISOName { get; set; }

    }
}
