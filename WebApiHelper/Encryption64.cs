﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace WebApiHelper
{

    public class Crypt : IDisposable
    {
        /// <summary>
        /// Converting Existing String Into Encrpted Format
        /// </summary>
        /// <param name="Text">The Text of the record to update.</param>
        /// <param name="Key">The Key of the record to update.</param>
        /// <returns>Return String Representing Encrypted Text</returns>
        /// <remarks></remarks>
        public string EncryptText(string Text, string Key)
        {
            return Encrypt(Text, Key);
        }

        /// <summary>
        /// Decrypts the text.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Key">The key.</param>
        /// <returns>String Representing Decrypted Text</returns>
        /// <remarks></remarks>
        public string DecryptText(string Text, string Key)
        {
            return Decrypt(Text, Key);
        }

        /// <summary>
        /// Encrypts the specified STR text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="strEncrKey">The encryption key.</param>
        /// <returns>String Representing Encrypted Text</returns>
        /// <remarks></remarks>
        private string Encrypt(string strText, string strEncrKey)
        {
            //byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

            byte[]  byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts the specified STR text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="sDecrKey">The s decryption key.</param>
        /// <returns>Representing Decrypted Text</returns>
        /// <remarks></remarks>
        private string Decrypt(string strText, string sDecrKey)
        {
            //byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[strText.Length + 1];

            byte[] byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                inputByteArray = Convert.FromBase64String(strText);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    return encoding.GetString(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Computes the MD5 hash value for the given string and converts the result into a Base64 encoded string.
        /// This string is directly comparable with and storable in the User table as a password.
        /// </summary>
        /// <param name="sToHash">String to hash and encode</param>
        /// <returns>MD5 hashed, Base64 encoded value of the given string</returns>
        /// <remarks></remarks>
        public static string CreateMD5HashedBase64String(string sToHash)
        {
            using (MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider())
            {
                return Convert.ToBase64String(md5Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sToHash)));
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }

    public static class Crypto
    {
        private const string PrivateKey = "TH#&^$HSJB$@#^GGHWF&)!&^@*(#$HJDY";
        /// <summary>
        /// Encrypts the specified STR to encrypt.
        /// </summary>
        /// <param name="strToEncrypt">The STR to encrypt.</param>
        /// <returns></returns>
        public static string Encrypt(this String strToEncrypt)
        {
            WebApiHelper.Crypt objCrypt = new WebApiHelper.Crypt();
            return objCrypt.EncryptText(strToEncrypt, PrivateKey).Replace("/", "~").Replace("+", "_");
        }

        /// <summary>
        /// Decrypts the specified STR to decrypt.
        /// </summary>
        /// <param name="strToDecrypt">The STR to decrypt.</param>
        /// <returns></returns>
        //public static string Decrypt(this String strToDecrypt)
        //{
        //    Crypt objCrypt = new Crypt();
        //    return objCrypt.DecryptText(strToDecrypt, "TH#&^$HSJB$@#^GGHWF&)!&^@*(#$HJDY");
        //}

        /// <summary>
        /// Decrypts the specified STR to decrypt.
        /// </summary>
        /// <param name="strToDecrypt">The STR to decrypt.</param>
        /// <param name="IsQueryStringParameter">if set to <c>true</c> [is query string parameter].</param>
        /// <returns></returns>
        public static string Decrypt(this String strToDecrypt, bool IsQueryStringParameter = true)
        {
            WebApiHelper.Crypt objCrypt = new WebApiHelper.Crypt();
            return objCrypt.DecryptText(IsQueryStringParameter ? strToDecrypt.Replace("_", "+").Replace("~", "/") : strToDecrypt, PrivateKey);
        }

    }


}