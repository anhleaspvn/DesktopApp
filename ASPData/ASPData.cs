using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASPData
{
    public class ASPData
    {
        public string ASPEncrypt(string strDecrypt)
        {
            try
            {
                string strPassword = "HaThanhLeHuu";
                byte[] bytes = Encoding.Unicode.GetBytes(strDecrypt);

                using (Rijndael rijndael = Rijndael.Create())
                {
                    PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(strPassword, new byte[13]
                    {
                      (byte) 38,
                      (byte) 25,
                      (byte) 129,
                      (byte) 78,
                      (byte) 160,
                      (byte) 109,
                      (byte) 149,
                      (byte) 52,
                      (byte) 38,
                      (byte) 117,
                      (byte) 100,
                      (byte) 5,
                      (byte) 246
                    });
                    rijndael.Key = passwordDeriveBytes.GetBytes(32);
                    rijndael.IV = passwordDeriveBytes.GetBytes(16);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, bytes.Length);
                            cryptoStream.Close();
                        }
                        strDecrypt = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }

            }
            catch
            {
                //MessageBox.Show("Encrypt text is wrong, can't decrypt it !!");
            }
            return strDecrypt;
        }
        public string ASPDecrypt(string strEncrypt)
        {
            try
            {
                string strPassword = "HaThanhLeHuu";
                strEncrypt = strEncrypt.Replace(" ", "+");
                byte[] buffer = Convert.FromBase64String(strEncrypt);
                using (Rijndael rijndael = Rijndael.Create())
                {
                    PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(strPassword, new byte[13]
                    {
                    (byte) 38,
                    (byte) 25,
                    (byte) 129,
                    (byte) 78,
                    (byte) 160,
                    (byte) 109,
                    (byte) 149,
                    (byte) 52,
                    (byte) 38,
                    (byte) 117,
                    (byte) 100,
                    (byte) 5,
                    (byte) 246
                    });

                    rijndael.Key = passwordDeriveBytes.GetBytes(32);
                    rijndael.IV = passwordDeriveBytes.GetBytes(16);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(buffer, 0, buffer.Length);
                            cryptoStream.Close();
                        }
                        strEncrypt = Encoding.Unicode.GetString(memoryStream.ToArray());
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Decrypt text is wrong, can't decrypt it !!");
            }
            return strEncrypt;
        }
    }
}
