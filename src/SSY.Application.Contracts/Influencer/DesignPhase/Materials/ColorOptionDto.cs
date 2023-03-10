namespace SSY.Influencer.Influencer.Materials
{
    public class ColorOptionDto
    {
        public int ColorOptionId { get; set; }
        public string ColorOptionName { get; set; }
        public string HexCode { get; set; }

        public string SelectedApprovalOption { get; set; }

        public bool ApprovalOptionConfirmed { get; set; }
    }
}
