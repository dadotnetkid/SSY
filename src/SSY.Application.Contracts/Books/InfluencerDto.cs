using System;
using SSY.Authors;
using Volo.Abp.Application.Dtos;

namespace SSY.Books;

public class InfluencerDto : AuditedEntityDto<Guid>
{
    public Guid AuthorId { get; set; }
    public AuthorDto Author { get; set; }

    public string SecondName { get; set; }

    public string Name { get; set; }

    public BookType Type { get; set; }

    public string Status { get; set; }

    public float Price { get; set; }
}