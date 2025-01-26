using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Utility
{
    public class RegistryUtility
    {
        public static bool TryLocalMachineGetValue(string keyName, string name, out string resultValue, out Exception exception, string defaultValue)
        {
            #region Reference
            // https://stackoverflow.com/questions/14213020/getting-windows-serial-number-was-getting-machineguid-from-registry
            #endregion

            try
            {
                string x64Result = string.Empty;
                string x86Result = string.Empty;
                RegistryKey keyBaseX64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey keyBaseX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                RegistryKey keyX64 = keyBaseX64.OpenSubKey(keyName, RegistryKeyPermissionCheck.ReadSubTree);
                RegistryKey keyX86 = keyBaseX86.OpenSubKey(keyName, RegistryKeyPermissionCheck.ReadSubTree);
                object resultObjX64 = keyX64.GetValue(name, defaultValue);
                object resultObjX86 = keyX86.GetValue(name, defaultValue);
                keyX64.Close();
                keyX86.Close();
                keyBaseX64.Close();
                keyBaseX86.Close();
                keyX64.Dispose();
                keyX86.Dispose();
                keyBaseX64.Dispose();
                keyBaseX86.Dispose();
                keyX64 = null;
                keyX86 = null;
                keyBaseX64 = null;
                keyBaseX86 = null;

                if (resultObjX64 != null && resultObjX64.ToString() != defaultValue)
                {
                    resultValue = resultObjX64.ToString();
                    exception = null;
                    return true;
                }
                else if (resultObjX86 != null && resultObjX86.ToString() != defaultValue)
                {
                    resultValue = resultObjX86.ToString();
                    exception = null;
                    return true;
                }
                else
                {
                    resultValue = defaultValue;
                    exception = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Toolkit.TraceWriteLine(ex);
                resultValue = null;
                exception = ex;
                return false;
            }
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography\MachineGuid 값을 가져옵니다. 
        /// <para></para>
        /// </summary>
        /// <param name="machineGuid"></param>
        /// <param name="exception"></param>
        /// <param name="defaultValue"></param>
        /// <returns>값을 가져오는데 성공하였을경우 True 실패하였을경우 False</returns>
        public static bool TryGetMachineGuid(out string machineGuid, out Exception exception, string defaultValue = "default")
        {
            #region Reference
            // https://stackoverflow.com/questions/14213020/getting-windows-serial-number-was-getting-machineguid-from-registry
            #endregion

            bool result = TryLocalMachineGetValue(@"SOFTWARE\Microsoft\Cryptography", "MachineGuid", out machineGuid, out exception, defaultValue);
            return result;
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 에디션 값에 해당합니다.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetOsProductName()
        {
            string productName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            return productName;
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 에디션 값에 해당합니다.</para>
        /// <paramref name="productName"/>
        /// </summary>
        /// <returns></returns>
        public bool TryGetOsProductName(out string productName)
        {
            try
            {
                productName = GetOsProductName();
                if (String.IsNullOrEmpty(productName))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                productName = null;
                return false;
            }
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 버전 값에 해당합니다.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetDisplayVersion()
        {
            string displayVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "DisplayVersion", "").ToString();
            return displayVersion;
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 버전 값에 해당합니다.</para>
        /// <paramref name="displayVersion"/>
        /// </summary>
        /// <returns></returns>
        public bool TryGetDisplayVersion(out string displayVersion)
        {
            try
            {
                displayVersion = GetDisplayVersion();
                if (String.IsNullOrEmpty(displayVersion))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                displayVersion = null;
                return false;
            }
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 OS 빌드 값 . 앞에 4자리값에 해당합니다.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentBuild()
        {
            string currentBuild = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "").ToString();
            return currentBuild;
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 OS 빌드 값 . 앞에 4자리값에 해당합니다.</para>
        /// <paramref name="currentBuild"/>
        /// </summary>
        /// <returns></returns>
        public bool TryGetCurrentBuild(out string currentBuild)
        {
            try
            {
                currentBuild = GetCurrentBuild();
                if (String.IsNullOrEmpty(currentBuild))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                currentBuild = null;
                return false;
            }
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 OS 빌드 값 . 뒤에 4자리값에 해당합니다.</para>
        /// </summary>
        /// <returns></returns>
        public static string GetUBR()
        {
            string ubr = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "UBR", "").ToString();
            return ubr;
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductName 값을 가져옵니다. 
        /// <para>Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보/Windows 사양 OS 빌드 값 . 뒤에 4자리값에 해당합니다.</para>
        /// <paramref name="ubr"/>
        /// </summary>
        /// <returns></returns>
        public bool TryGetUBR(out string ubr)
        {
            try
            {
                ubr = GetUBR();
                if (String.IsNullOrEmpty(ubr))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                ubr = null;
                return false;
            }
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRoot 값을 가져옵니다. 
        /// <para>윈도우즈 설치 위치를 가져옵니다. 예) C:\\Windows</para>
        /// </summary>
        /// <returns></returns>
        public static string GetSystemRoot()
        {
            string systemRoot = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", "").ToString();
            return systemRoot;
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRoot 값을 가져옵니다. 
        /// <para>윈도우즈 설치 위치를 가져옵니다. 예) C:\\Windows</para>
        /// <paramref name="systemRoot"/>
        /// </summary>
        /// <returns></returns>
        public bool TryGetSystemRoot(out string systemRoot)
        {
            try
            {
                systemRoot = GetSystemRoot();
                if (String.IsNullOrEmpty(systemRoot))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                systemRoot = null;
                return false;
            }
        }

        /// <summary>
        /// 레지스트리 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProductId 값을 가져옵니다. 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="exception"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool TryGetProductId(out string productId, out Exception exception, string defaultValue = "default")
        {
            bool result = TryLocalMachineGetValue(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductId", out productId, out exception, defaultValue);
            return result;
        }
    }
}
