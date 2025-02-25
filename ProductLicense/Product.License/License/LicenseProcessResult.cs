using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public enum LicenseProcessResult
    {
        /// <summary>
        /// 초기화
        /// </summary>
        Init,

        /// <summary>
        /// License.key 파일을 못찾을 경우
        /// </summary>
        FileNotFoundLicenseKey,

        /// <summary>
        /// 암복호화 모듈 생성에 실패 하였을 경우
        /// </summary>
        FailedCreateCrypto,

        /// <summary>
        /// 암복호화 모듈 생성에 실패 하였을 경우
        /// </summary>
        FailedUserCreateCrypto,

        #region InitLicenseProductData

        /// <summary>
        /// InitLicenseProduct.data 파일을 못찾을 경우
        /// </summary>
        FileNotFoundInitLicenseProductData,

        /// <summary>
        /// InitLicenseProduct.data 생성에 실패 하였을 경우
        /// </summary>
        FailedCreateInitLicenseProductData,

        /// <summary>
        /// InitLicenseProduct.data 파일 읽는중 오류가 발생하였을 경우
        /// </summary>
        FailedReadInitLicenseProductDataFile,

        /// <summary>
        /// InitLicenseProduct.data 파일 에서 읽어온 데이터 복호화 작업중 오류가 발생하였을 경우
        /// </summary>
        FailedDecryptInitLicenseProductData,

        /// <summary>
        /// InitLicenseProduct.data 파일 에서 읽어온 데이터 복호화 후 LicenseProductData 클래스로 파싱중 오류 발생
        /// </summary>
        FailedParseInitPlainText,

        #endregion

        #region ExecLicenseProduct

        /// <summary>
        /// ExecLicenseProduct.data 파일을 못찾을 경우
        /// </summary>
        FileNotFoundExecLicenseProductData,

        /// <summary>
        /// ExecLicenseProduct.data 생성에 실패 하였을 경우
        /// </summary>
        FailedCreateExecLicenseProductDataFile,

        /// <summary>
        /// ExecLicenseProduct.data 파일 읽는중 오류가 발생하였을 경우
        /// </summary>
        FailedReadExecLicenseProductDataFile,

        /// <summary>
        /// InitLicenseProduct.data 파일 에서 읽어온 데이터에 KeyValues값 합쳐서 실행 라이선스 데이터 암호화중 오류가 발생하였을 경우
        /// </summary>
        FailedEncryptExecLicenseProductData,

        /// <summary>
        /// ExecLicenseProduct.data 파일 에서 읽어온 데이터 복호화 중 오류 발생
        /// </summary>
        FailedDecryptExecLicenseProductData,

        /// <summary>
        /// ExecLicenseProduct.data 파일 에서 읽어온 데이터 복호화 후 LicenseProductData 클래스로 파싱중 오류 발생
        /// </summary>
        FailedParseExecPlainText,

        #endregion

        #region Verify

        /// <summary>
        /// MachineGuid 값이 일치 하지 않을 경우
        /// </summary>
        NotEqualMachineGuid,

        /// <summary>
        /// MacAddress 값이 일치 하지 않을 경우
        /// </summary>
        NotEqualMacAddress,

        /// <summary>
        /// 현재 날짜보다 IssueDateTime 값이 큰 경우
        /// </summary>
        IssueDateTime,

        /// <summary>
        /// 현재 날짜가 ExpireDateTime 보다 클 경우
        /// </summary>
        ExpireDateTime,

        /// <summary>
        /// 초기화 성공(라이선스 검증 준비 완료)
        /// </summary>
        InitSuccess,

        /// <summary>
        /// 검증 성공
        /// </summary>
        ValidationSuccess

        #endregion
    }
}
