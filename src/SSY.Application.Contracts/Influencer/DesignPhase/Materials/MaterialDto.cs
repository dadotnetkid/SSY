using System;
using System.Collections.Generic;
using System.Text;

namespace SSY.Influencer.Influencer.Materials
{
    public class MaterialDto
    {
        public string MaterialTypeName { get; set; }

        public List<ProductTypeDto> ProductTypeList { get; set; }

        public List<ColorOptionDto> ColorOptionList { get; set; }
    }
}
