using System;
using Volo.Abp;

namespace SSY.Authors;

public class AuthorAlreadyExistsException : BusinessException
{
    public AuthorAlreadyExistsException(string name)
        : base(SSYDomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}