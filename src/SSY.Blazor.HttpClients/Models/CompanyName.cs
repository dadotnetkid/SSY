using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{
    public class CompanyName
    {
        public List<Compname> rc2 { get; set; } = new();

        public CompanyName()
        {

            Compname[] rec = new Compname[] {
                new Compname{ Id = 1, ISOName = "SewSew You" },
                new Compname{ Id = 2, ISOName = "APAC AFF" },

            };
            rc2.AddRange(rec);
        }
    }
    public class Compname
    {
        //https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        //https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population
        //https://www.iso.org/iso-3166-country-codes.html

        public int Id { get; set; }
        public string ISOName { get; set; }

    }
}
