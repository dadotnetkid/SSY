using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Influencer.Influencer.DesignPhase.VirtualFitting
{
    public class VirtualFittingTypeDto
    {
        public int VirtualFittingTypeId { get; set; }

        public string VirtualFittingTypeName { get; set; }

        public string VirtualFittingDisplayImage { get; set; }

        public string SelectedApprovalOption { get; set; }

        public bool ApprovalOptionConfirmed { get; set; }
    }
}
