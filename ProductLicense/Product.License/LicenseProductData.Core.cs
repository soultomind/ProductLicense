using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public partial class LicenseProductData
    {
        public static readonly char PropertyCollectionSplitChar = '&';
        public static readonly char PropertyKeyValueSplitChar = '=';

        public static readonly string RuntimeEnvironmentSize = "RuntimeEnvironmentSize";

        public string GeneratePlainText()
        {
            // PlainText 구성 방향
            // 1. PlainText 를 QueryString 형태로 구성
            // 2. JSON 형태로 구성

            // 최초 KeyValue 에는 KeyValuePairs 정보의 길이 정보로 설정하여 작업을 진행한다.
            // 예) RuntimeEnvironmentSize=2&ExecMachineGuid=928ef79e-6840-4f0d-82be-e1ae9075f9b8&MacAddress=34:E1:2D:5F:18:DD

            StringBuilder builder = new StringBuilder(256);
            if (KeyValuePairs.Count > 0)
            {
                builder.Append(RuntimeEnvironmentSize).Append(PropertyKeyValueSplitChar).Append(KeyValuePairs.Count);
                builder.Append(PropertyCollectionSplitChar);
                foreach (var keyValuePair in KeyValuePairs)
                { 
                    builder.Append(keyValuePair.Key).Append(PropertyKeyValueSplitChar).Append(keyValuePair.Value);
                    builder.Append(PropertyCollectionSplitChar);
                }
            }
            builder.Append(nameof(Ids)).Append(PropertyKeyValueSplitChar).Append(SplitCharProductIds);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(IssueDate)).Append(PropertyKeyValueSplitChar).Append(IssueDate);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(ExpireDate)).Append(PropertyKeyValueSplitChar).Append(ExpireDate);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(LicenseNo)).Append(PropertyKeyValueSplitChar).Append(LicenseNo);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(CustomerName)).Append(PropertyKeyValueSplitChar).Append(CustomerName);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(ProjectName)).Append(PropertyKeyValueSplitChar).Append(ProjectName);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(OperationMode)).Append(PropertyKeyValueSplitChar).Append(OperationMode.ToString());

            return builder.ToString();
        }

        public string GenerateLicenseData(bool withMachineGuid = false)
        {
            StringBuilder builder = new StringBuilder(256);
            if (withMachineGuid)
            {
                builder.Append(nameof(ExecMachineGuid)).Append(PropertyKeyValueSplitChar).Append(ExecMachineGuid);
                builder.Append(PropertyCollectionSplitChar);
            }
            builder.Append(nameof(Ids)).Append(PropertyKeyValueSplitChar).Append(SplitCharProductIds);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(IssueDate)).Append(PropertyKeyValueSplitChar).Append(IssueDate);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(ExpireDate)).Append(PropertyKeyValueSplitChar).Append(ExpireDate);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(LicenseNo)).Append(PropertyKeyValueSplitChar).Append(LicenseNo);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(CustomerName)).Append(PropertyKeyValueSplitChar).Append(CustomerName);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(ProjectName)).Append(PropertyKeyValueSplitChar).Append(ProjectName);
            builder.Append(PropertyCollectionSplitChar);

            builder.Append(nameof(OperationMode)).Append(PropertyKeyValueSplitChar).Append(OperationMode.ToString());

            return builder.ToString();
        }

        public static LicenseProductData Parse(string plainText)
        {
            LicenseProductData p = new LicenseProductData();

            string[] propertyCollection = plainText.Split(PropertyCollectionSplitChar);
            foreach (string property in propertyCollection)
            {
                string name = property.Split(PropertyKeyValueSplitChar)[0];
                string value = property.Split(PropertyKeyValueSplitChar)[1];
                if (nameof(Ids).Equals(name))
                {
                    //p.Code = value;
                }
                else if (nameof(IssueDate).Equals(name))
                {
                    p.IssueDateTime = DateTime.Parse(value);
                }
                else if (nameof(ExpireDate).Equals(name))
                {
                    p.ExpireDateTime = DateTime.Parse(value);
                }
                else if (nameof(LicenseNo).Equals(name))
                {
                    p.LicenseNo = value;
                }
                else if (nameof(CustomerName).Equals(name))
                {
                    p.CustomerName = value;
                }
                else if (nameof(ProjectName).Equals(name))
                {
                    p.ProjectName = value;
                }
                else if (nameof(OperationMode).Equals(name))
                {
                    p.OperationMode = (OperationMode)Enum.Parse(typeof(OperationMode), value);
                }
                else if (nameof(ExecMachineGuid).Equals(name))
                {
                    p.ExecMachineGuid = value;
                }
            }

            return p;
        }
    }
}
