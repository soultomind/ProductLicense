using Product.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public class Aes256CBCKeyData
    {
        /// <summary>
        /// 라이선스 파일 경로
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// <see cref="Path"/> 값으로 부터 읽어드린 바이트 정보
        /// </summary>
        public IList<byte> ReadBytes { get; internal set; }

        /// <summary>
        /// Aes256 CBC IVBase64 정보
        /// </summary>
        public string IVBase64 { get; set; }

        /// <summary>
        /// Aes256 CBC IVBase64 디코딩 정보
        /// </summary>
        public string PlainIV
        {
            get
            {
                return ConvertUtility.Base64Decode(IVBase64);
            }
        }

        /// <summary>
        /// Aes256 CBC KeyBase64 정보
        /// </summary>
        public string KeyBase64 { get; set; }

        /// <summary>
        /// Aes256 CBC KeyBase64 디코딩 정보
        /// </summary>
        public string PlainKey
        {
            get
            {
                return ConvertUtility.Base64Decode(KeyBase64);
            }
        }

        public Aes256CBCKeyData()
        {

        }

        public Aes256CBCKeyData(string path)
        {
            Path = path;
            ReadBytes = new List<byte>();
        }
    }
}
