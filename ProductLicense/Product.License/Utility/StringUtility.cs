using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Utility
{
    public class StringUtility
    {
        public static bool IsBase64(string base64)
        {
            // Reference: https://stackoverflow.com/questions/6309379/how-to-check-for-a-valid-base64-encoded-string
            if (String.IsNullOrEmpty(base64) ||
                base64.Length % 4 != 0 ||
                base64.Contains(" ") ||
                base64.Contains("\t") ||
                base64.Contains("\r") ||
                base64.Contains("\n"))
            {
                return false;
            }


            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch (Exception)
            {
                // Handle the exception
            }
            return false;
        }

        public static bool TryBase64(string value, out byte[] outBytes, out Exception outException)
        {
            if (String.IsNullOrEmpty(value) ||
                value.Length % 4 != 0 ||
                value.Contains(" ") ||
                value.Contains("\t") ||
                value.Contains("\r") ||
                value.Contains("\n"))
            {
                outBytes = null;
                outException = new ArgumentException(nameof(value));
                return false;
            }

            try
            {
                outBytes = Convert.FromBase64String(value);
                outException = null;
                return true;
            }
            catch (Exception exception)
            {
                outBytes = null;
                outException = exception;
                return false;
            }
        }
    }
}
