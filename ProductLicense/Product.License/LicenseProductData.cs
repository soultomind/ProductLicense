using Product.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public partial class LicenseProductData
    {
        #region Static

        static LicenseProductData()
        {
            DateTimeFormat = "yyyyMMdd";
        }

        /// <summary>
        /// <see cref="IssueDate"/>, <see cref="ExpireDate"/> 사용시 내부적으로 사용되는 날짜포맷값
        /// </summary>
        public static string DateTimeFormat
        {
            get { return dateTimeFormat; }
            set
            {
                string now = DateTime.Now.ToString(value);
                dateTimeFormat = value;
            }
        }
        private static string dateTimeFormat;

        #endregion

        #region 

        public string ExecMachineGuid
        {
            get; set;
        }

        public string MacAddress
        {
            get; set;
        }

        public IDictionary<RuntimeEnvironment, string> KeyValuePairs
        {
            get;
            internal set;
        } = new Dictionary<RuntimeEnvironment, string>();

        #endregion

        public const char IdSplitChar = ',';

        public string SplitCharIds
        {
            get
            {
                return String.Join(IdSplitChar.ToString(), Ids.ToArray());
            }
        }

        public IList<int> Ids
        {
            get;
            internal set;
        } = new List<int>();

        /// <summary>
        /// 발행 날짜
        /// </summary>
        public DateTime IssueDateTime
        {
            get; set;
        }

        /// <summary>
        /// <see cref="IssueDateTime"/> 값의 년(Year),월(Month), 일(Day) 값을 <see cref="DateTimeFormat"/> 포맷값 형태의 문자열
        /// </summary>
        public string IssueDate
        {
            get
            {
                if (issueDate == null)
                {
                    issueDate = IssueDateTime.ToString(DateTimeFormat);
                }
                return issueDate;
            }
        }
        private string issueDate;

        /// <summary>
        /// 끝 날짜
        /// </summary>
        public DateTime ExpireDateTime { get; set; }

        /// <summary>
        /// <see cref="ExpireDateTime"/> 값의 년(Year),월(Month), 일(Day) 값을 <see cref="DateTimeFormat"/> 포맷값 형태의 문자열
        /// </summary>
        public string ExpireDate
        {
            get
            {
                if (expireDate == null)
                {
                    expireDate = ExpireDateTime.ToString(DateTimeFormat);
                }
                return expireDate;
            }
        }
        private string expireDate;

        /// <summary>
        /// 라이선스 번호
        /// </summary>
        public string LicenseNo
        {
            get; set;
        } = String.Empty;

        /// <summary>
        /// 고객사 이름
        /// </summary>
        public string CustomerName
        {
            get; set;
        } = String.Empty;


        /// <summary>
        /// 프로젝트 이름
        /// </summary>
        public string ProjectName
        {
            get; set;
        } = String.Empty;

        public RuntimeEnvironment RuntimeEnvironment
        {
            get; set;
        } = RuntimeEnvironment.Client;

        public OperationMode OperationMode
        {
            get; set;
        } = OperationMode.Dev;

        private LicenseProductData()
        {

        }

        private LicenseProductData(IList<int> ids, DateTime issueDateTime)
            : this(ids, issueDateTime, new DateTime(DateTime.MaxValue.Ticks))
        {

        }

        public LicenseProductData(IList<int> ids, DateTime issueDateTime, DateTime expireDateTime)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Count == 0)
            {
                throw new ArgumentException(nameof(ids));
            }

            if (!(expireDateTime.Ticks >= issueDateTime.Ticks))
            {
                throw new ArgumentException();
            }

            Ids = ids;
            IssueDateTime = issueDateTime;
            ExpireDateTime = expireDateTime;
        }

        private static IList<int> ConvertProductIdList(string strProductId)
        {
            IList<int> list = new List<int>();
            foreach (string id in strProductId.Split(LicenseProductData.IdSplitChar))
            {
                list.Add(int.Parse(id));
            }
            return list;
        }

        private static string ConvertProductIdString(IList<int> idList)
        {
            string strProductId = String.Join(IdSplitChar.ToString(), idList.ToArray());
            return strProductId;
        }

        public static LicenseProductData NewProd(string strProductId, DateTime issueDateTime)
        {
            IList<int> ids = ConvertProductIdList(strProductId);

            LicenseProductData products = new LicenseProductData(ids, issueDateTime);
            products.OperationMode = OperationMode.Prod;
            return products;
        }

        public static LicenseProductData NewProd(IList<int> ids, DateTime issueDateTime)
        {
            LicenseProductData products = new LicenseProductData(ids, issueDateTime);
            products.OperationMode = OperationMode.Prod;
            return products;
        }

        public static LicenseProductData NewDev(string strProductId, DateTime expireDateTime)
        {
            IList<int> idList = ConvertProductIdList(strProductId);
            return NewDev(idList, expireDateTime);
        }

        public static LicenseProductData NewDev(IList<int> idList, DateTime expireDateTime)
        {
            DateTime issueDateTime = DateTimeExtension.ToNowSetTimeYearMonthDayExceptTimeZero();
            return NewDev(idList, issueDateTime, expireDateTime);
        }

        public static LicenseProductData NewDev(string strProductId, DateTime issueDateTime, DateTime expireDateTime)
        {
            IList<int> idList = ConvertProductIdList(strProductId);
            return NewDev(idList, issueDateTime, expireDateTime);
        }

        public static LicenseProductData NewDev(IList<int> idList, DateTime issueDateTime, DateTime expireDateTime)
        {
            LicenseProductData products = new LicenseProductData(idList, issueDateTime, expireDateTime);
            products.OperationMode = OperationMode.Dev;
            return products;
        }
    }
}
