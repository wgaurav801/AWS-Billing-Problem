using CsvHelper.Configuration.Attributes;
using System;

namespace BillingEngine.Parsers.Models
{
    public class ParsedEc2InstanceType
    {
        [Name("Instance Type")]
        public string Ec2InstanceType { get; set; }
        [Name("Charge/Hour")]
        public decimal CostPerHour { get; set; }
    }
}