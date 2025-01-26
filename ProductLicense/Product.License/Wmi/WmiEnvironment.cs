using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Product.Wmi
{
    public class WmiEnvironment
    {
        /// <summary>
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/장치 사양 제품 ID 값에 해당합니다.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetSerialNumber()
        {
            ManagementObject managementObject = new ManagementObject("Win32_OperatingSystem=@");
            string serialNumber = (string)managementObject["SerialNumber"];
            return serialNumber;
        }

        public static string GetMacAddress()
        {
            string path = "Win32_NetworkAdapterConfiguration";
            ManagementClass managementClass = new ManagementClass(path);
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();

            string macAddress = String.Empty;
            foreach (ManagementObject managetmentObject in managementObjectCollection)
            {
                if (macAddress == String.Empty)
                {
                    // only return MAC Address from first card
                    if ((bool)managetmentObject["IPEnabled"] == true)
                    {
                        macAddress = managetmentObject["MacAddress"].ToString();
                    }
                }
                managetmentObject.Dispose();
            }
            return macAddress;
        }

        public static string GetFastMacAddress()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            return mac;
        }

        /// <summary>
        /// <paramref name="query"/> 값 명령의 결과값을 반환합니다.
        /// <para>SELECT * FROM Win32_NetworkAdapterConfiguration</para>
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="query"></param>
        /// <param name="isNullValueAppend"></param>
        /// <returns></returns>
        public static string ToStringQueryResult(string namespaceName, string query, bool isNullValueAppend)
        {
            ManagementPath managementPath = new ManagementPath();
            managementPath.Path = namespaceName;
            ManagementScope managementScope = new ManagementScope(managementPath);
            ObjectQuery objectQuery = new ObjectQuery(query);
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection objectCollection = objectSearcher.Get();

            StringBuilder builder = new StringBuilder(1024);
            foreach (ManagementObject managementObject in objectCollection)
            {
                PropertyDataCollection props = managementObject.Properties;
                foreach (PropertyData prop in props)
                {
                    if (isNullValueAppend)
                    {
                        builder.AppendFormat("Property name: {0}", prop.Name).AppendLine();
                        builder.AppendFormat("Property type: {0}", prop.Type).AppendLine();
                        builder.AppendFormat("Property value: {0}", prop.Value).AppendLine();
                    }
                    else
                    {
                        if (prop.Value != null)
                        {
                            builder.AppendFormat("Property name: {0}", prop.Name).AppendLine();
                            builder.AppendFormat("Property type: {0}", prop.Type).AppendLine();
                            builder.AppendFormat("Property value: {0}", prop.Value).AppendLine();
                        }
                    }
                }

                builder.AppendLine().AppendLine();
            }

            return builder.ToString();
        }
    }
}
