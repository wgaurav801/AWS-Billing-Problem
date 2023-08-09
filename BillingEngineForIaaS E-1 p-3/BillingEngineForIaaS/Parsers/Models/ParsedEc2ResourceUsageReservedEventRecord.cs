using CsvHelper.Configuration.Attributes;

namespace BillingEngineForIaaS.Parsers.Models
{
    public class ParsedEc2ResourceUsageReservedEventRecord
    {

        [Name("Customer ID")]
        public string CustomerId { get; set; }

        [Name("EC2 Instance ID")]
        public string Ec2InstanceId { get; set; }

        [Name("EC2 Instance Type")]
        public string Ec2InstanceType { get; set; }

        [Name("Start Date")]
        public DateTime UsedFrom { get; set; }


        [Name("End Date")]
        public DateTime UsedUntil { get; set; }

        [Name("Region")]
        public string Region { get; set; }

        [Name("OS")]
        public string OS { get; set; }
    }
}
