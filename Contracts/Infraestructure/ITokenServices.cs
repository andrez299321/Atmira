using Dto.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Infraestructure
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, LoginRequest user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
