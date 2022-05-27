using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password , out byte[] passwordHash, out byte[] passwordSalt)// Girilen şifre için hash oluşturacak.
        {//out byte[] girilen passwordun hashini dışarı dönecek bir yöntem.Geriye değer döndürme gibi düşünülebilir.
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //Cryptography HMACSHA512 bir algoritması.
            {
                passwordSalt=hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//Kullanıcının verdiği şifreyi (password) ComputeHash metodu ile hashleyip passwordHashe atıyoruz.

            }
        }

        public static bool VerifyPasswordHash(string password,byte[] passwordHash, byte[] passwordSalt) //Oturum açmak isteyen kullanıcının girdiği şifreyi veritabanındaki şifre ile  hash yönetimi kullanarak karşılaştırıyor.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //Encoding.UTF8.GetBytes(password)  password string değeri byte dönüştürüyoruz.
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Kullanıcının girdiği şifreyi doğrulamak için hashliyioruz.

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])// girilen şifrenin hashi ile veritabanındaki şifrenin hashi aynı mı kontrol ediyoruz.(karakter karakter)
                    {
                        return false;//elit değilse false döneceğiz.Şifre yanlış demektir.
                    }
                }
            }
            return true;//Şifre doğru demektir.
        }
    }
}
