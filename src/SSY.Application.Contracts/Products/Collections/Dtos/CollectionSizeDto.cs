using System;
using SSY.Products.Sizes.Dtos;
using System.Collections.Generic;
using System.Text;

namespace SSY.Products.Collections.Dtos
{
    public class CollectionSizeDto
    {
        public Guid? TenantId { get; set; }
        public bool IsActive { get; set; }

        public Guid CollectionId { get; set; }
        public SizeDto Size { get; set; }
    }
}
