using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken // Erişim anahtarı : Bir işlem yaparken yetkilendirme için verilecek anahtar ve zamanı içerecek.
    {
        public string Token { get; set; } 
        public DateTime Expiration { get; set; } //Token süresi.
    }
}
