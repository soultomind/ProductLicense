using Product.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public class Aes256CBCKeyGenerator
    {
        public static bool DevelopMode = true;

        public const int IVLength = 48;
        public const int KeyLength = 88;

        #region Read

        internal static void ReadIVBase64(FileStream fsRead, Aes256CBCKeyData data, ref int startReadByteIndex, ref int countReadByteIndex, int ivLength)
        {
            while (true)
            {
                int value = fsRead.ReadByte();
                if (countReadByteIndex >= startReadByteIndex)
                {
                    data.ReadBytes.Add((byte)value);
                }

                if (value == -1 || data.ReadBytes.Count == ivLength)
                {
                    break;
                }

                countReadByteIndex++;
            }
        }

        internal static void ReadKeyBase64(FileStream fsRead, Aes256CBCKeyData data, ref int startReadByteIndex, ref int countReadByteIndex, int keyLength)
        {
            while (true)
            {
                int value = fsRead.ReadByte();
                data.ReadBytes.Add((byte)value);

                if (value == -1)
                {
                    break;
                }

                countReadByteIndex++;
            }
        }

        public static Aes256CBCKeyData ToAes256CBCKeyData(string path)
        {
            Aes256CBCKeyData data = new Aes256CBCKeyData(path);

            int startReadByteIndex = 0;
            int countReadByteIndex = 0;

            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                ReadIVBase64(fsRead, data, ref startReadByteIndex, ref countReadByteIndex, IVLength);

                StringBuilder builder = new StringBuilder(64);
                for (int i = 0; i < data.ReadBytes.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        byte first = data.ReadBytes[i - 1];
                        byte second = data.ReadBytes[i];
                        char keyChar = ConvertChar(first, second);
                        builder.Append(keyChar);
                    }
                }

                string base64 = builder.ToString();
                data.IVBase64 = base64;

                ReadKeyBase64(fsRead, data, ref startReadByteIndex, ref countReadByteIndex, KeyLength);

                builder.Clear();

                for (int i = IVLength; i < data.ReadBytes.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        byte first = data.ReadBytes[i - 1];
                        byte second = data.ReadBytes[i];
                        char keyChar = ConvertChar(first, second);
                        builder.Append(keyChar);
                    }
                }

                base64 = builder.ToString();
                data.KeyBase64 = base64;
            }

            return data;
        }

        #endregion

        #region Write

        public static bool TryGetDecryptedBase64(IList<byte> keyBase64Bytes, out string outBase64)
        {
            try
            {
                StringBuilder builder = new StringBuilder(64);
                for (int i = 0; i < keyBase64Bytes.Count; i++)
                {
                    if (i % 2 == 1 && i + 2 != keyBase64Bytes.Count)
                    {
                        byte first = keyBase64Bytes[i - 1];
                        byte second = keyBase64Bytes[i];
                        char keyChar = ConvertChar(first, second);
                        builder.Append(keyChar);
                    }
                }

                string base64 = builder.ToString();
                outBase64 = base64;
                return true;
            }
            catch (Exception)
            {
                outBase64 = null;
                return false;
            }
        }

        #region IV
        public static bool TryGetEncryptedIVBase64(string ivPlainText, out string outBase64)
        {
            try
            {
                string base64 = ConvertUtility.Base64Encode(ivPlainText);
                if (Aes256CBCCrypto.IsValidIVBase64(base64))
                {
                    outBase64 = base64;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Toolkit.TraceWriteLine(ex);
            }

            outBase64 = null;
            return false;
        }

        public static bool TryGetEncryptedIVBase64(string ivPlainText, out string outIVEncryptedBase64, out IList<byte> outIVBase64Bytes)
        {
            if (TryGetEncryptedIVBase64(ivPlainText, out outIVEncryptedBase64))
            {
                string base64 = outIVEncryptedBase64;
                outIVBase64Bytes = new List<byte>();
                AddBase64ConvertHexChar(base64, outIVBase64Bytes);
                return true;
            }

            outIVBase64Bytes = null;
            return false;
        }
        #endregion

        #region Key
        public static bool TryGetEncryptedKeyBase64(string plainText, out string outBase64)
        {
            try
            {
                string base64 = ConvertUtility.Base64Encode(plainText);
                if (Aes256CBCCrypto.IsValidKeyBase64(base64))
                {
                    outBase64 = base64;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Toolkit.TraceWriteLine(ex);
            }

            outBase64 = null;
            return false;
        }

        public static bool TryGetEncryptedKeyBase64(string keyPlainText, out string outKeyEncryptedBase64, out IList<byte> outKeyBase64Bytes)
        {
            if (TryGetEncryptedKeyBase64(keyPlainText, out outKeyEncryptedBase64))
            {
                string base64 = outKeyEncryptedBase64;
                outKeyBase64Bytes = new List<byte>();
                AddBase64ConvertHexChar(base64, outKeyBase64Bytes);
                return true;
            }

            outKeyBase64Bytes = null;
            return false;
        }
        #endregion

        private static void AddBase64ConvertHexChar(string base64, IList<byte> base64Bytes)
        {
            foreach (char ch in base64)
            {
                string strCode = ((int)ch).ToString();
                int dec = int.Parse(strCode);
                string hex = dec.ToString("X2");
                for (int i = 0; i < hex.Length; i++)
                {
                    char hexValue = hex[i];
                    byte value = (byte)ConvertUtility.ToInt32HexChar(hexValue);
                    base64Bytes.Add(value);
                }
            }
        }

        #endregion

        private static char ConvertChar(byte first, byte second)
        {
            string strHexAsCode = ConvertHexAsCode(first, second);
            string strDecAsCode = Convert.ToInt32(strHexAsCode, 16).ToString();
            int decAsCode = int.Parse(strDecAsCode);
            char keyChar = (char)decAsCode;
            if (DevelopMode)
            {
                Toolkit.TraceWriteLine(String.Format("First={0}, Second={1}", first, second));
                Toolkit.TraceWriteLine(String.Format("Dec={0}, Hex={1}, Char={2}", strDecAsCode, strHexAsCode, keyChar));
            }

            return keyChar;
        }

        private static string ConvertHexAsCode(byte first, byte second)
        {
            return ToStringHexNumber(first) + "" + ToStringHexNumber(second);
        }

        private static string ToStringHexNumber(byte value)
        {
            return ConvertUtility.ToStringHexNumber(value);
        }
    }
}
