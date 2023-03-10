using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using SSY.Products.Options.Dtos;

namespace SSY.Products.Types.Dtos;

public class TypeOptionDto
{
    public int OptionId { get; set; }
    public int? OptionParentId { get; set; }
    public string OptionLabel { get; set; }
    public string OptionValue { get; set; }
    public bool OptionHasPanel { get; set; }
    public string MaterialIds { get; set; }
    public List<OptionDto> OptionOptions { get; set; }
}