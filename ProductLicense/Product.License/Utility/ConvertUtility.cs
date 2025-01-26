using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Utility
{
    public class ConvertUtility
    {
        #region Hex Char,String => Int32, Hex Number(1-F) -> Hex Char,String

        /// <summary>
        /// <paramref name="hexValue"/> 값을 16진수 기준(0-F) 문자열 값으로 반환합니다. 
        /// <para>값이 0이면 문자0, 값이 11이면 문자B</para>
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="hexValue"/> 값이 0-15 범위에 해당하지 않을 경우</exception>
        public static string ToStringHexNumber(int hexValue)
        {
            char ch = ToCharHexNumber(hexValue);
            return new string(new char[] { ch });
        }

        /// <summary>
        /// <paramref name="hexValue"/> 값을 16진수 기준(0-F) 문자 값으로 반환합니다. 
        /// <para>값이 0이면 문자0, 값이 11이면 문자B</para>
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="hexValue"/> 값이 0-15 범위에 해당하지 않을 경우</exception>
        public static char ToCharHexNumber(int hexValue)
        {
            if (!(hexValue >= 0 && hexValue <= 15))
            {
                throw new ArgumentException(nameof(hexValue) + " is 0-15");
            }

            if (hexValue >= 10)
            {
                if (hexValue == 10)
                {
                    return 'A';
                }
                else if (hexValue == 11)
                {
                    return 'B';
                }
                else if (hexValue == 12)
                {
                    return 'C';
                }
                else if (hexValue == 13)
                {
                    return 'D';
                }
                else if (hexValue == 14)
                {
                    return 'E';
                }
                else if (hexValue == 15)
                {
                    return 'F';
                }
            }
            char ch = hexValue.ToString()[0];
            return ch;
        }

        /// <summary>
        /// <paramref name="hexValue"/> 값을 정수로 반환합니다. 0-15(0-F)
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static int ToInt32HexString(string hexValue)
        {
            return ToInt32HexChar(hexValue[0]);
        }

        /// <summary>
        /// <paramref name="hexValue"/> 값을 정수로 반환합니다. 0-15(0-F)
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static int ToInt32HexChar(char hexValue)
        {
            if (!IsHexNumberChar(hexValue))
            {
                throw new ArgumentException();
            }

            int value = 0;
            if ((hexValue >= 'A' && hexValue <= 'F') || (hexValue >= 'a' && hexValue <= 'f'))
            {
                if (hexValue == 'A' || hexValue == 'a')
                {
                    value = 10;
                }
                else if (hexValue == 'B' || hexValue == 'b')
                {
                    value = 11;
                }
                else if (hexValue == 'C' || hexValue == 'c')
                {
                    value = 12;
                }
                else if (hexValue == 'D' || hexValue == 'd')
                {
                    value = 13;
                }
                else if (hexValue == 'E' || hexValue == 'e')
                {
                    value = 14;
                }
                else
                {
                    value = 15;
                }
            }
            else
            {
                value = int.Parse(hexValue.ToString());
            }
            return value;
        }

        /// <summary>
        /// <paramref name="ch"/> 문자 값이 0-9, A(10)-F(15) 에 속하는지 여부를 나타냅니다.
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool IsHexNumberChar(char ch)
        {
            if ((ch >= '0' && ch <= '9') ||
                ((ch >= 'A' && ch <= 'F') || (ch >= 'a' && ch <= 'f')))
            {
                return true;
            }

            return false;
        }

        #endregion

        /// <summary>
        /// 해당 문자열을 Base64 형태로 인코딩하여 반환
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encodingName"></param>
        /// <returns></returns>
        public static string Base64Encode(string text, string encodingName = "UTF-8")
        {
            byte[] bytes = GetBytes(text, encodingName);
            return ToBase64String(bytes);
        }

        /// <summary>
        /// 해당 Base64 문자열을 디코딩하여 반환
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Base64Decode(string text)
        {
            byte[] bytes = FromBase64String(text);
            return GetString(bytes);
        }

        private static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        private static byte[] FromBase64String(string text)
        {
            return Convert.FromBase64String(text);
        }

        private static byte[] GetBytes(string text, string encodingName = "UTF-8")
        {
            Encoding encoding = Encoding.GetEncoding(encodingName);
            if (encoding != null)
            {
                return encoding.GetBytes(text);
            }
            return null;
        }

        private static string GetString(byte[] bytes, string encodingName = "UTF-8")
        {
            Encoding encoding = Encoding.GetEncoding(encodingName);
            if (encoding != null)
            {
                return encoding.GetString(bytes);
            }
            return null;
        }
    }
}
