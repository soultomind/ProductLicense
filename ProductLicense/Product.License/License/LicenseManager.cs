﻿using Product.Extension;
using Product.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.License
{
    public class LicenseManager
    {
        #region Static

        public static bool DevelopMode = true;

        /// <summary>
        /// 라이선스 검증이 가능한지 여부
        /// </summary>
        public static readonly bool CanVerify;

        public static readonly string MachineGuid;
        public static readonly Exception MachineGuidException;

        public static readonly string MacAddress;
        public static readonly Exception MacAddressException;

        public static readonly string LicenseKeyFilePath;
        public static readonly string InitLicenseProductDataFilePath;
        public static readonly string ExecLicenseProductDataFilePath;

        public static Func<string, ICrypto> UserCrypto;

        static LicenseManager()
        {
#if !DEBUG
            {
                DevelopMode = false;
            }
#endif

            Toolkit.TraceWriteLine("Start static LicenseManager()");

            bool bMachineGuid = true, bMacAddress = true;

            string machineGuid = null;
            Exception exception = null;
            if (RegistryUtility.TryGetMachineGuid(out machineGuid, out exception))
            {
                MachineGuid = machineGuid;
                if (DevelopMode)
                {
                    Toolkit.TraceWriteLine("MachineGuid=" + machineGuid);
                }
            }
            else
            {
                Toolkit.TraceWriteLine("Error getting MachineGuid value");
                Toolkit.TraceWriteLine(exception.StackTrace);
                MachineGuidException = exception;
                bMachineGuid = false;
            }

            string macAddress = null;
            if (NetworkUtility.TryGetMacAddress(out macAddress, out exception))
            {
                MacAddress = macAddress;
                if (DevelopMode)
                {
                    Toolkit.TraceWriteLine("MacAddress=" + machineGuid);
                }
            }
            else
            {
                Toolkit.TraceWriteLine("Error getting MacAddress value");
                Toolkit.TraceWriteLine(exception.StackTrace);
                MacAddressException = exception;
                bMacAddress = false;
            }

            if (bMachineGuid && bMacAddress)
            {
                CanVerify = true;
                Toolkit.TraceWriteLine("CanVeriify True.");

                string value = ConfigurationManager.AppSettings[nameof(LicenseKeyFilePath)];
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.IndexOf("%ExecuteDirectory%") != -1)
                    {
                        value = value.Replace("%ExecuteDirectory%", ExecuteContext.Directory);
                        LicenseKeyFilePath = value;
                    }
                    else
                    {
                        LicenseKeyFilePath = value;
                    }
                }
                else
                {
                    LicenseKeyFilePath = ExecuteContext.Directory + Path.DirectorySeparatorChar + "License.key";
                }

                value = ConfigurationManager.AppSettings[nameof(InitLicenseProductDataFilePath)];
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.IndexOf("%ExecuteDirectory%") != -1)
                    {
                        value = value.Replace("%ExecuteDirectory%", ExecuteContext.Directory);
                        InitLicenseProductDataFilePath = value;
                    }
                    else
                    {
                        InitLicenseProductDataFilePath = value;
                    }
                }
                else
                {
                    InitLicenseProductDataFilePath = ExecuteContext.Directory + Path.DirectorySeparatorChar + "InitLicenseProduct.data";
                }

                value = ConfigurationManager.AppSettings[nameof(ExecLicenseProductDataFilePath)];
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.IndexOf("%ExecuteDirectory%") != -1)
                    {
                        value = value.Replace("%ExecuteDirectory%", ExecuteContext.Directory);
                        ExecLicenseProductDataFilePath = value;
                    }
                    else
                    {
                        ExecLicenseProductDataFilePath = value;
                    }
                }
                else
                {
                    ExecLicenseProductDataFilePath = ExecuteContext.Directory + Path.DirectorySeparatorChar + "ExecLicenseProduct.data";
                }
            }
            else
            {
                if (!bMachineGuid)
                {
                    Toolkit.TraceWriteLine("The current MachineGuid value is not valid. Check the LicenseManager.MachineGuidException property value");
                }

                if (!bMacAddress)
                {
                    Toolkit.TraceWriteLine("The current MacAddress value is not valid. Check the LicenseManager.MacAddressException property value");
                }
            }

            Toolkit.TraceWriteLine("Finish static LicenseManager()");
        }

        #endregion

        public const string KeyFileFilter = "Product License KeyFile |*.key";
        public const string DataFileFilter = "Product License Data |*.data";

        /// <summary>
        /// 처리 결과
        /// </summary>
        public LicenseProcessResult ProcessResult { get; internal set; } = LicenseProcessResult.Init;

        /// <summary>
        /// 예외
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// 초기화 라이선스 데이터 파일 경로
        /// </summary>
        public string InitDataFilePath { get; internal set; }

        /// <summary>
        /// 실행 라이선스 데이터 파일 경로
        /// </summary>
        public string ExecDataFilePath { get; internal set; }

        /// <summary>
        /// 라이선스 키 파일 경로
        /// </summary>
        public string KeyFilePath { get; internal set; }

        /// <summary>
        /// 라이선스 데이터 암복호화 인터페이스
        /// </summary>
        public ICrypto Crypto { get; internal set; }

        public LicenseManager(string keyFilePath)
        {
            KeyFilePath = keyFilePath;
            if (!File.Exists(LicenseKeyFilePath))
            {
                ProcessResult = LicenseProcessResult.FileNotFoundLicenseKey;
            }
        }

        public bool Verify()
        {
            string execEncryptedText = String.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(ExecDataFilePath))
                {
                    execEncryptedText = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Exception = ex;
                ProcessResult = LicenseProcessResult.FailedReadExecLicenseProductDataFile;
                return false;
            }

            return Verify(execEncryptedText);
        }

        /// <summary>
        /// 암호화된 실행 라이선스 데이터(<paramref name="encryptedText"/>) 를 검증합니다.
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public bool Verify(string encryptedText)
        {
            string plainText = String.Empty;
            try
            {
                plainText = Crypto.Decrypt(encryptedText);
            }
            catch (Exception ex)
            {
                Exception = ex;
                ProcessResult = LicenseProcessResult.FailedDecryptExecLicenseProductData;
                return false;
            }

            LicenseProductData p = null;

            try
            {
                p = LicenseProductData.Parse(plainText);
            }
            catch (Exception ex)
            {
                Exception = ex;
                ProcessResult = LicenseProcessResult.FailedParseExecPlainText;
                return false;
            }

            return Verify(p);
        }

        internal bool Verify(LicenseProductData p)
        {
            bool bValidation = true;
            if (!p.ExecMachineGuid.Equals(MachineGuid))
            {
                //ConsoleAppendText("MachineGuid 값이 일치하지 않습니다. 관리자에게 문의하세요.");
                bValidation = false;
                ProcessResult = LicenseProcessResult.NotEqualMachineGuid;
            }
            else
            {
                //ConsoleAppendText("MachineGuid 인증성공");
            }

            if (!p.ExecMacAddress.Equals(MacAddress))
            {
                bValidation = false;
                ProcessResult = LicenseProcessResult.NotEqualMacAddress;
            }
            else
            {

            }

            // IssueDateTime, ExpireDateTime 은 날짜까지만 비교
            DateTime now = DateTimeExtension.ToNowSetTimeYearMonthDayExceptTimeZero();
            if (bValidation)
            {
                DateTime t1 = p.IssueDateTime, t2 = now.Date;
                int result = DateTime.Compare(t1, t2);

                //if (p.IssueDateTime.Date > now.Date)
                if (result > 0)
                {
                    //ConsoleAppendText(String.Format("해당 라이선스는 {0} 날짜부터 사용이 가능합니다.", now));
                    bValidation = false;
                    ProcessResult = LicenseProcessResult.IssueDateTime;
                }
                else
                {
                    //ConsoleAppendText("IssueDateTime 인증 성공");
                }
            }

            if (bValidation)
            {
                DateTime t1 = p.ExpireDateTime, t2 = now.Date;
                int result = DateTime.Compare(t1, t2);

                //if (p.ExpireDateTime.Date < now.Date)
                if (result < 0)
                {
                    //ConsoleAppendText("라이선스 유효기간이 지났습니다. 관리자에게 문의하세요.");
                    bValidation = false;
                    ProcessResult = LicenseProcessResult.ExpireDateTime;
                }
                else
                {
                    //ConsoleAppendText("ExpireDateTime 인증 성공");
                }
            }

            return bValidation;
        }

        private static LicenseManager NewInitLicenseManager(string licenseKeyFilePath)
        {
            if (!CanVerify)
            {
                throw new LicenseException("LicenseManager.CanVerify == False");
            }

            LicenseManager licenseManager = new LicenseManager(licenseKeyFilePath);
            if (licenseManager.ProcessResult == LicenseProcessResult.FileNotFoundLicenseKey)
            {
                return licenseManager;
            }

            if (UserCrypto != null)
            {
                try
                {
                    licenseManager.Crypto = UserCrypto.Invoke(licenseKeyFilePath);
                }
                catch (Exception ex)
                {
                    licenseManager.Exception = ex;
                    licenseManager.ProcessResult = LicenseProcessResult.FailedUserCreateCrypto;
                    return licenseManager;
                }
            }
            else
            {
                try
                {
                    string ivBase64 = String.Empty, keyBase64 = String.Empty;

                    Aes256CBCKeyData keyData = Aes256CBCKeyGenerator.ToAes256CBCKeyData(licenseKeyFilePath);
                    if (DevelopMode)
                    {
                        Toolkit.TraceWriteLine("IVBase64=" + keyData.IVBase64);
                        Toolkit.TraceWriteLine("KeyBase64=" + keyData.KeyBase64);
                    }

                    licenseManager.Crypto = new Aes256CBCCrypto(keyData.IVBase64, keyData.KeyBase64);
                }
                catch (Exception ex)
                {
                    licenseManager.Exception = ex;
                    licenseManager.ProcessResult = LicenseProcessResult.FailedCreateCrypto;
                    return licenseManager;
                }
            }

            return licenseManager;
        }

        /// <summary>
        /// 라이선스 검증 객체를 생성합니다.
        /// </summary>
        /// <param name="licenseKeyFilePath"></param>
        /// <param name="initLicenseDataFilePath"></param>
        /// <param name="execLicenseDataFilePath"></param>
        /// <returns></returns>
        /// <exception cref="LicenseException"><see cref="CanVerify"/> 값이 False 일때</exception>
        public static LicenseManager NewInitLicenseManager(string licenseKeyFilePath, string initLicenseDataFilePath, string execLicenseDataFilePath)
        {
            LicenseManager licenseManager = NewInitLicenseManager(licenseKeyFilePath);
            if (licenseManager.Exception != null)
            {
                return licenseManager;
            }

            if (!File.Exists(initLicenseDataFilePath))
            {
                licenseManager.ProcessResult = LicenseProcessResult.FileNotFoundInitLicenseProductData;
                return licenseManager;
            }

            string initEncryptedText = String.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(initLicenseDataFilePath))
                {
                    initEncryptedText = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                licenseManager.Exception = ex;
                licenseManager.ProcessResult = LicenseProcessResult.FailedReadInitLicenseProductDataFile;
                return licenseManager;
            }

            string initPlainText = null;
            try
            {
                initPlainText = licenseManager.Crypto.Decrypt(initEncryptedText);
            }
            catch (Exception ex)
            {
                licenseManager.Exception = ex;
                licenseManager.ProcessResult = LicenseProcessResult.FailedDecryptInitLicenseProductData;
                return licenseManager;
            }

            LicenseProductData product = null;
            try
            {
                product = LicenseProductData.Parse(initPlainText);
            }
            catch (Exception ex)
            {
                licenseManager.Exception = ex;
                licenseManager.ProcessResult = LicenseProcessResult.FailedParseInitPlainText;
                return licenseManager;
            }

            string execEncryptedText = null;
            try
            {
                string execPlainText = product.CreateExecPlainText();
                execEncryptedText = licenseManager.Crypto.Encrypt(execPlainText);
            }
            catch (Exception ex)
            {
                licenseManager.Exception = ex;
                licenseManager.ProcessResult = LicenseProcessResult.FailedEncryptExecLicenseProductData;
                return licenseManager;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(execLicenseDataFilePath))
                {
                    sw.WriteLine(execEncryptedText);
                }
                licenseManager.ExecDataFilePath = execLicenseDataFilePath;
            }
            catch (Exception ex)
            {
                licenseManager.Exception = ex;
                licenseManager.ProcessResult = LicenseProcessResult.FailedCreateExecLicenseProductDataFile;
                return licenseManager;
            }

            licenseManager.ProcessResult = LicenseProcessResult.InitSuccess;
            return licenseManager;
        }

        /// <summary>
        /// 라이선스 검증 객체를 생성합니다. <paramref name="licenseKeyFilePath"/> 값에 해당하는 라이선스 키 파일, <paramref name="execLicenseDataFilePath"/> 실행 라이선스 데이터 파일이 존재 할 경우 해당 인터페이스를 이용합니다.
        /// </summary>
        /// <param name="licenseKeyFilePath"></param>
        /// <param name="execLicenseDataFilePath"></param>
        /// <returns></returns>
        /// <exception cref="LicenseException"><see cref="CanVerify"/> 값이 False 일때</exception>
        public static LicenseManager NewExecLicenseManager(string licenseKeyFilePath, string execLicenseDataFilePath)
        {
            LicenseManager licenseManager = NewInitLicenseManager(licenseKeyFilePath);
            if (licenseManager.Exception != null)
            {
                return licenseManager;
            }
            licenseManager.ExecDataFilePath = execLicenseDataFilePath;

            licenseManager.ProcessResult = LicenseProcessResult.InitSuccess;
            return licenseManager;
        }
    }
}
