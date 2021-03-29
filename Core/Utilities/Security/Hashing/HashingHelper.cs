using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //create hash for password
                //bir stringin byte versiyonunu almak için Encoding.UTF8.GetBytes() kullanılır
            }
        }
        public static bool VerifyPasswordHash
            (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //passwordHash oluşturulduktan sonra veritabanında saklanır,
            //kullanıcı girdiğinde ise salt değeri ile passwordHash hesaplanır,
            //veritabanındaki hash ile sonradan tekrar oluşturulan hash karşılaştırılır.

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    //byte array olduğu için böyle karşılaştırılıyor.
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
