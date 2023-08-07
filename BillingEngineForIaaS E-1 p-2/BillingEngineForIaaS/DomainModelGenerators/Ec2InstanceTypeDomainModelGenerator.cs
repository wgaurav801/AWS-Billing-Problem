using BillingEngine.Models.Ec2;
using BillingEngine.Parsers.Models;

namespace BillingEngine.DomainModelGenerators
{
    public class Ec2InstanceTypeDomainModelGenerator
    {

        public List<Ec2InstanceType> GenerateEc2InstanceTypes(List<ParsedEc2InstanceType> parsedEc2InstanceTypes)
        {
            var sc = parsedEc2InstanceTypes.Select(record => generateEc2InstanceType(record.Ec2InstanceType, double.Parse(record.CostPerHourOnDemand[1..]),record.Region)).ToList();
            // Convert each object of type ParsedEc2InstanceType to Ec2InstanceType

            return sc;
        }

        private Ec2InstanceType generateEc2InstanceType(string Ec2InstanceType, double CostPerHour, string Region)
        {
            Ec2InstanceType sc = new Ec2InstanceType(Ec2InstanceType, CostPerHour,Region);
            return sc;
        }

    }
}