using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public interface IAesCrypto
    {
        AesCryptoServiceProvider CreateAesCryptoServiceProvider(AesCryptoServiceProviderCreateData createData);
    }
}
