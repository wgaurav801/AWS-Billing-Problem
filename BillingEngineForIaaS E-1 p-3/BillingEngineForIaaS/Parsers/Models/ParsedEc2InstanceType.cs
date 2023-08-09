using CsvHelper.Configuration.Attributes;

namespace BillingEngine.Parsers.Models
{
    public class ParsedEc2InstanceType
    {
        [Name("Instance Type")]
        public string Ec2InstanceType { get; set; }
        [Name("Charge/Hour(OnDemand)")]
        public string CostPerHourOnDemand { get; set; }

        [Name("Charge/Hour(Reserved)")]
        public string CostPerHourReserved { get; set; }

        [Name("Region")]
        public string Region { get; set; }
    }
}