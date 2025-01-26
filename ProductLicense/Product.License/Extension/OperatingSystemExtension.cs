using Product.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Extension
{
    /// <summary>
    /// 운영체제정보 확장 클래스
    /// <para>지원하는 기능</para>
    /// <para>- Windows 10 기준 바탕화면/마우스 오른쪽 버튼 클릭 메뉴/개인설정 홈/업데이트 및 보안/관련링크 OS 빌드 및 시스템 정보 에 나오는 정보</para>
    /// </summary>
    public class OperatingSystemExtension
    {
        /// <summary>
        /// 장치 사양 / 제품 ID 
        /// </summary>
        public static string ProductId
        {
            get
            {
                string productId = String.Empty;

                Exception exception = null;
                bool result = RegistryUtility.TryGetProductId(out productId, out exception);
                if (result)
                {
                    return productId;
                }
                return String.Empty;
            }
        }

        /// <summary>
        /// Windows 사양 / 에디션
        /// <para><see cref="RegistryUtility.GetOsProductName()"/></para>
        /// </summary>
        public static string Edition
        {
            get
            {
                return RegistryUtility.GetOsProductName();
            }
        }

        /// <summary>
        /// Windows 사양 / 버전
        /// <para><see cref="RegistryUtility.GetDisplayVersion()"/></para>
        /// </summary>
        public static string Version
        {
            get
            {
                return RegistryUtility.GetDisplayVersion();
            }
        }

        /// <summary>
        /// Windows 사양 / OS 빌드
        /// <para><see cref="RegistryUtility.GetCurrentBuild()"/> + <see cref="RegistryUtility.GetUBR()"/></para>
        /// </summary>
        public static string Build
        {
            get
            {
                return RegistryUtility.GetCurrentBuild() + "." + RegistryUtility.GetUBR();
            }
        }
    }
}
