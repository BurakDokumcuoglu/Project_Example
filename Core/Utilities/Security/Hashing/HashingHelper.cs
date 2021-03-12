using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassWordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //Bir password'ün hash'ini oluşturmaya yarayan metod. 
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPassWordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //veritabanından gelen passwordHash ile kullanıcının gönderdiği password'ün hashlenmiş halinin
            //eşleşip eşleşmemesine göre doğrulama(verify) yapılır.(Kullanıcın şifresiyle giriş yapmaya çalışması işlemi sırasında)
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  // Bu satırda kullancının girdiği password hashlenir 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
