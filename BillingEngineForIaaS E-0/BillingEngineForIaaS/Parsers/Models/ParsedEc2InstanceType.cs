using CsvHelper.Configuration.Attributes;

namespace BillingEngine.Parsers.Models
{
    public class ParsedEc2InstanceType
    {
        [Name("Instance Type")]
        public string Ec2InstanceType { get; set; }
        [Name("Charge/Hour")]
        public string CostPerHour { get; set; }
    }
}