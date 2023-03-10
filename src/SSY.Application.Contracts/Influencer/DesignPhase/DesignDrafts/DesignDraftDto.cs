using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Influencer.Influencer.DesignPhase.DesignDrafts
{
    public class DesignDraftDto
    {
        public int DesignDraftId { get; set; }

        public string DesignDraftName { get; set; }

        public List<DesignDraftTypeDto> DesignDraftTypeList { get; set; }
        public List<DesignDraftTypeDto> DesignDraftTypeDetailsList { get; set; }
    }
}
