using BillingEngine.Models.Ec2;
using BillingEngine.Parsers.Models;

namespace BillingEngine.DomainModelGenerators
{
    public class Ec2InstanceTypeDomainModelGenerator
    {

        public List<Ec2InstanceType> GenerateEc2InstanceTypes(List<ParsedEc2InstanceType> parsedEc2InstanceTypes, List<Ec2Region> ec2Regions)
        {
            var sc = parsedEc2InstanceTypes.Select(record => generateEc2InstanceType(record.Ec2InstanceType, double.Parse(record.CostPerHourOnDemand[1..]), double.Parse(record.CostPerHourReserved[1..]), record.Region, ec2Regions)).ToList();
            // Convert each object of type ParsedEc2InstanceType to Ec2InstanceType

            return sc;
        }

        private Ec2InstanceType generateEc2InstanceType(string Ec2InstanceType, double CostPerHourOnDemand, double CostPerHourReserved, string Region, List<Ec2Region> ec2Regions)
        {
            // Ec2InstanceType sc = new Ec2InstanceType(Ec2InstanceType, CostPerHour,Region);
            foreach (var ec2Region in ec2Regions)
            {
                if (Ec2InstanceType == ec2Region.FreeTierEligibleInstanceType && Region == ec2Region.Name)
                {
                    return new Ec2InstanceType(Ec2InstanceType, CostPerHourOnDemand, CostPerHourReserved, Region, true);
                }
                else
                {
                }
            }

            return new Ec2InstanceType(Ec2InstanceType, CostPerHourOnDemand, CostPerHourReserved, Region, false);
        }

    }
}