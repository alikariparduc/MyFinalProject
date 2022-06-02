using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) // appsettings.jsondaki güvenlik anahtarı parametre olarak verilecek.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//Encoding.UTF8.GetBytes(securityKey) stringi byte çeviriyor ve new SymmetricSecurityKey ile return ediyor.
        }
    }
}
