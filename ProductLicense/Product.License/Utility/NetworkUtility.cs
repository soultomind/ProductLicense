using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Product.Utility
{
    public class NetworkUtility
    {
        private static string ConvertMacAddress(string macAddress, string separator = ":")
        {
            StringBuilder builder = new StringBuilder(32);
            int Length = macAddress.Length;
            for (int index = 0; index < Length; index++)
            {
                builder.Append(macAddress[index]);
                if ((index + 1) % 2 == 0 && index + 1 != Length)
                {
                    builder.Append(separator);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// 네트워크 MacAddress 주소를 반환합니다.
        /// <para>가상화 환경을 고려하여 작동중인 맥주소중에 물리적으로 보내고 받은 데이터중 가장 많이 보내고 받은 주소를 반환함.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            IDictionary<string, long> dic = new Dictionary<string, long>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    // 보내고 받은 데이터를 합친다.
                    dic[ni.GetPhysicalAddress().ToString()] = ni.GetIPStatistics().BytesSent + ni.GetIPStatistics().BytesReceived;
                }
            }

            long max = 0;
            string macAddress = String.Empty;
            foreach (KeyValuePair<string, long> pair in dic)
            {
                if (pair.Value > max)
                {
                    macAddress = pair.Key;
                    max = pair.Value;
                }
            }

            return ConvertMacAddress(macAddress);
        }
    }
}
