using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Global.Utility
{
    public class Hashing
    {
        public static string SHA256Generator(string strInput)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            //provide the string in byte format to the ComputeHash method. 
            //This method returns the SHA-256 hash code in byte array
            byte[] arrHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(strInput));

            // use a Stringbuilder to append the bytes from the array to create a SHA-256 hash code string.
            StringBuilder sbHash = new StringBuilder();

            // Loop through byte array of the hashed code and format each byte as a hexadecimal code.
            for (int i = 0; i < arrHash.Length; i++)
            {
                sbHash.Append(arrHash[i].ToString("x2"));
            }

            // Return the hexadecimal SHA-256 hash code string.
            return sbHash.ToString();
        }
    }
}
