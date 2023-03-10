using System.Collections.Generic;

namespace SSY.Products.Typeforms.Dtos.Response;

public class TypeFormResponseDto
{
    public List<string> Types { get; set; }
    public List<InfluencerDto> TypeForms { get; set; }
}