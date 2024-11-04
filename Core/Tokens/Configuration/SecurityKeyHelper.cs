
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Tokens.Configuration;

public static class SecurityKeyHelper
{
    public static SecurityKey GetSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}

