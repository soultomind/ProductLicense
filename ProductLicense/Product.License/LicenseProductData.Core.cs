using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public partial class LicenseProductData
    {
        public static readonly char PropertyCollectionSplitChar = ';';
        public static readonly char PropertyKeyValueSplitChar = '=';



        public string GenerateLicenseData(bool withMachineGuid = false)
        {
            StringBuilder builder = new StringBuilder(256);
            if (withMachineGuid)
            {
                builder.Append(nameof(ExecMachineGuid)).Append(PropertyKeyValueSplitChar).Append(ExecMachineGuid);
                builder.Append(PropertyCollectionSplitChar);
            }
            builder.Append(nameof(Ids)).Append(PropertyKeyValueSplitChar).Append(SplitCharIds);
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
