using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public class LicenseException : Exception
    {
        public LicenseException(string message)
            : base(message)
        {

        }

        public LicenseException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
