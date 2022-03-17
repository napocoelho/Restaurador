using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Restaurador.Helpers
{
    public class CryptographyHelper
    {
        public static string Code(string text, string key)
        {
            try
            {
                var objcriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = key;

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objcriptografaSenha.Key = byteHash;
                objcriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = ASCIIEncoding.ASCII.GetBytes(text);

                return Convert.ToBase64String(objcriptografaSenha.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }


        public static string Decode(string codedText, string key)
        {
            try
            {
                var objdescriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = key;

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objdescriptografaSenha.Key = byteHash;
                objdescriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = Convert.FromBase64String(codedText);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objdescriptografaSenha.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objdescriptografaSenha = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }
    }
}
