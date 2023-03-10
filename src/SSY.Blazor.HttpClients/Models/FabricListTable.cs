using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSY.Blazor.HttpClients.Models
{

    public class FabricListTable
    {
        public List<FabricTable> FabricList { get; set; }
        public FabricListTable()
        {
        }
    }
    public class FabricTable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ColorCode { get; set; }
        public string ItemCode { get; set; }
        public double ActualCount { get; set; }
        public double ReservedCount { get; set; }
        public double AvailableCount { get; set; }
        public double UsedCount { get; set; }
        public string UnitMeasurement { get; set; }

    }
}