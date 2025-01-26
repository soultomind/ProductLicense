using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public interface ICrypto
    {
        /// <summary>
        /// <paramref name="plainText"/> 값을 암호화 합니다.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string Encrypt(string plainText);

        /// <summary>
        /// <see cref="ICrypto.Encrypt(string)"/> 인터페이스로 암호화된 문자열값을 복호화 합니다.
        /// </summary>
        /// <param name="enryptedText"></param>
        /// <returns></returns>
        string Decrypt(string enryptedText);
    }
}
