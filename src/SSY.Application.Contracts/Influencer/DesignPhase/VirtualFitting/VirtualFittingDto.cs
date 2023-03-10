using System.Collections.Generic;

namespace SSY.Influencer.Influencer.DesignPhase.VirtualFitting
{
    public class VirtualFittingDto
    {
        public int VirtualFittingId { get; set; }

        public string VirtualFittingName { get; set; }

        public List<VirtualFittingTypeDto> VirtualFittingTypeList { get; set; }
        public List<VirtualFittingTypeDto> VirtualFittingTypeDetailsList { get; set; }
    }
}
