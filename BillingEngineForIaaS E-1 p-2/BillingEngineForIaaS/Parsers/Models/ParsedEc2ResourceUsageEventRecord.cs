using BillingEngine.Models.Ec2;
using CsvHelper.Configuration.Attributes;

namespace BillingEngine.Parsers.Models
{
    public class ParsedEc2ResourceUsageEventRecord
    {
        [Name("Customer ID")]
        public string CustomerId { get; set; }

        [Name("EC2 Instance ID")]
        public string Ec2InstanceId { get; set; }

        [Name("EC2 Instance Type")]
        public string Ec2InstanceType { get; set; }

        [Name("Used From")]
        public DateTime UsedFrom { get; set; }


        [Name("Used Until")]
        public DateTime UsedUntil { get; set; }

        [Name("Region")]
        public string Region { get; set; }

        [Name("OS")]
        public string Os { get; set; }
    }
}