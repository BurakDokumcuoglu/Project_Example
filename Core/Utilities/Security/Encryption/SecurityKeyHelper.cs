using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
            //Json Web Token'da oluşturulan security key döndürülüyor.  securityKey kullanacağımız anahtardır.
            //Metod içindeki parametre ise hangi algoritmayı kullanacağımızı gösterir
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
