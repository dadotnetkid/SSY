using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{
    public class Fabric
    {
        public string name { get; set; }
        public string Type { get; set; }
        public string ColorCode { get; set; }
        public string ItemCode { get; set; }
        public double ActualCount { get; set; }
        public double ReservedCount { get; set; }
        public double AvailableCount { get; set; }
        public double UsedCount { get; set; }


    }
}