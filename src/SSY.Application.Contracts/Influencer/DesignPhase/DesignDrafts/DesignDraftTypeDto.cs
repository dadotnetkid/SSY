using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Influencer.Influencer.DesignPhase.DesignDrafts
{
    public class DesignDraftTypeDto
    {
        public int DesignDraftTypeId { get; set; }

        public string DesignDraftTypeName { get; set; }

        public string DesignDraftDisplayImage { get; set; }

        public string SelectedApprovalOption { get; set; }

        public bool ApprovalOptionConfirmed { get; set; }

    }
}
