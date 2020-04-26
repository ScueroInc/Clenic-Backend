using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MyE.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyE.Business.Component.Helpers
{
    public static class SecurityHelper
    {
        private static string AES_IV = "tm7T7Rz#$nuQ%3k_";
        private static string AES_KEY = "u?$$bM2XuE5y2CV*55mNvQruAa+xw5C^";
        private static string SESSION_TOKEN_DURATION_HOURS = "1";
        public static string EncryptText(string plainText)
        {
            var iv = Encoding.UTF8.GetBytes(AES_IV);
            var key = Encoding.UTF8.GetBytes(AES_KEY);
            var plainBytes = Encoding.UTF8.GetBytes(plainText);

            var rijndael = Rijndael.Create();
            var encryptor = rijndael.CreateEncryptor(key, iv);
            var memoryStream = new MemoryStream(plainBytes.Length);

            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();

            var cipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherBytes);
        }
        public static string DecryptText(string cipherText)
        {
            var iv = Encoding.UTF8.GetBytes(AES_IV);
            var key = Encoding.UTF8.GetBytes(AES_KEY);

            var cipherBytes = Convert.FromBase64String(cipherText);
            var plainBytes = new byte[cipherBytes.Length];

            var rijndael = Rijndael.Create();
            var decryptor = rijndael.CreateDecryptor(key, iv);

            var memoryStream = new MemoryStream(cipherBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            var decryptedByteCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            var plainText = Encoding.UTF8.GetString(plainBytes, 0, decryptedByteCount);

            return plainText;
        }
    
        public static string GenerateToken(Usuario objUsuario)
        {
            var contraseña = objUsuario.Psw;
            var usuario = objUsuario.UsuarioId;
            var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = Guid.NewGuid().ToByteArray();
            var tokenSinUsuario = Convert.ToBase64String(time.Concat(key).ToArray());
            var token = contraseña+usuario+tokenSinUsuario;
            token = EncryptText(token);
            return token;
        }
        public static void ValidateToken(string token)
        {
            try
            {
                token = DecryptText(token);

                var data = Convert.FromBase64String(token);
                var createdAt = DateTime.FromBinary(BitConverter.ToInt64(data, 0));

                var maxValidHours = int.Parse(SESSION_TOKEN_DURATION_HOURS);
                if (createdAt < DateTime.UtcNow.AddHours(maxValidHours * -1))   
                    throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception(ConstantsHelper.SESSION_EXPIRED_MESSAGE);
            }
        }
    }
}
