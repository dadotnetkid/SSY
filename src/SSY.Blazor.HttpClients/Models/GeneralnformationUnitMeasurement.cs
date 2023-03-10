using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{
    public class GeneralnformationUnitMeasurement
    {
        public List<genmom> rc2 { get; set; } = new();

        public GeneralnformationUnitMeasurement()
        {

            genmom[] rec = new genmom[] {
                new genmom{ Id = 1, ISOName = "Yard" },
                new genmom{ Id = 2, ISOName = "Meter" },


            };
            rc2.AddRange(rec);
        }
    }
    public class genmom
    {
        //https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        //https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population
        //https://www.iso.org/iso-3166-country-codes.html

        public int Id { get; set; }
        public string ISOName { get; set; }

    }
}
