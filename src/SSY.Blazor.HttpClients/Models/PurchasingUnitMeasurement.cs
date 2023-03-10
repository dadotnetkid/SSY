using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{
    public class PurchasingUnitMeasurement
    {
        public List<PUM> rc2 { get; set; } = new();

        public PurchasingUnitMeasurement()
        {

            PUM[] rec = new PUM[] {
                new PUM{ Id = 1, ISOName = "Yards" },
                new PUM{ Id = 2, ISOName = "Meter" },

            };
            rc2.AddRange(rec);
        }
    }
    public class PUM
    {
        //https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
        //https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population
        //https://www.iso.org/iso-3166-country-codes.html

        public int Id { get; set; }
        public string ISOName { get; set; }

    }
}
