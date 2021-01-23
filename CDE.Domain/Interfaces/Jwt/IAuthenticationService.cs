using System;
using System.Collections.Generic;
using System.Text;

namespace CDE.Domain.Interfaces.Jwt
{
    public interface IAuthenticationService
    {
        string GerarToken();
    }
}
