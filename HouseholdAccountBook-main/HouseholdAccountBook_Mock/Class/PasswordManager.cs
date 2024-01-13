using System;
using System.Text;
using System.Security.Cryptography;

namespace HouseholdAccountBook_Mock.Class
{
    public class PasswordManager : Singleton<PasswordManager>
    {
        #region 定数

        private const int SALT_SIZE = 24;
        private const int PBKDF2_ITERATION = 10000;

        #endregion

        #region メソッド
        // ハッシュ化...平文パスワードを渡すとハッシュ化パスワード、使用されたソルトが返る
        public static (string hashedPassword, string salt) HashPassword(string rawPassword)
        {
            string salt = GenerateSalt();
            string hashed = GeneratePasswordHashPBKDF2(rawPassword, salt);
            return (hashed, salt);
        }

        // 認証...ハッシュ化パスワード、平文パスワード・ソルトを渡すと正しいパスワードなら true が返る
        public static bool VerifyPassword(string hashedPassword, string rawPassword, string salt) =>
          hashedPassword == GeneratePasswordHashPBKDF2(rawPassword, salt);

        /// <summary>
        /// ソルト作成
        /// </summary>
        /// <returns></returns>
        private static string GenerateSalt()
        {
            var buff = new byte[SALT_SIZE];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buff);
            }
            return Convert.ToBase64String(buff);
        }

        private static string GeneratePasswordHashPBKDF2(string pwd, string salt)
        {
            Rfc2898DeriveBytes b = new Rfc2898DeriveBytes(pwd, new UTF8Encoding().GetBytes(salt), PBKDF2_ITERATION);
            var k = b.GetBytes(32);
            string result = Convert.ToBase64String(k);
            return result;
        }

        #endregion
            }
}
