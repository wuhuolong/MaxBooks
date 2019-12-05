/// <summary>
/// AES 加密解密
/// </summary>

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
   public class AES
   {
        /// <summary>AES加密</summary>
        /// <param name="text">明文</param>
        /// <param name="key">密钥, 长度为16的字符串</param>
        /// <param name="iv">偏移量, 长度为16的字符串</param>
        /// <returns>密文</returns>
        public static string Encode(string text, string key, string iv)
        {
            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
                len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);

            RijndaelManaged cipher = new RijndaelManaged();
            cipher.Mode = CipherMode.CBC;
            cipher.Padding = PaddingMode.Zeros;
            cipher.KeySize = 128;
            cipher.BlockSize = 128;
            cipher.Key = keyBytes;
            cipher.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform transform = cipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);

            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>AES解密</summary>
        /// <param name="text">密文</param>
        /// <param name="key">密钥, 长度为16的字符串</param>
        /// <param name="iv">偏移量, 长度为16的字符串</param>
        /// <returns>明文</returns>
        public static string Decode(string text, string key, string iv)
        {
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
                len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);
 
            RijndaelManaged cipher = new RijndaelManaged();
            cipher.Mode = CipherMode.CBC;
            cipher.Padding = PaddingMode.Zeros;
            cipher.KeySize = 128;
            cipher.BlockSize = 128;
            cipher.Key = keyBytes;
            cipher.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform transform = cipher.CreateDecryptor();
            byte[] encryptedData = Convert.FromBase64String(text);
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);

            return Encoding.UTF8.GetString(plainText);
        }
    }
}