using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace KLTN.Models
{
    public class MaHoaMatKhau
    {
        public static string EncryptPassword(string Password)
        {
            var _md5 = new MD5CryptoServiceProvider();
            var rawData = System.Text.ASCIIEncoding.ASCII.GetBytes(Password);
            var result = _md5.ComputeHash(rawData);
            return System.Convert.ToBase64String(result, 0, result.Length);
        }
    }
}