using BillingEngine.Models.Ec2;
using BillingEngine.Parsers.Models;

namespace BillingEngine.DomainModelGenerators
{
    public class Ec2InstanceDomainModelGenerator
    {
        private ResourceUsageEvent _resourceUsageEvent;

        public Ec2InstanceDomainModelGenerator()
        {
            _resourceUsageEvent = new ResourceUsageEvent();
        }
        public List<Ec2Instance> GenerateEc2InstanceModels(
            List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageTypeEventRecords,
            List<Ec2InstanceType> ec2InstanceTypes)
        {
            var list1 = parsedEc2ResourceUsageTypeEventRecords.Select(
                            record => generateEc2InstanceModel(record.Ec2InstanceId,parsedEc2ResourceUsageTypeEventRecords
                            , ec2InstanceTypes.FirstOrDefault(rec => ((record.Ec2InstanceType == rec.InstanceType) && (record.Region==rec.Region))))).ToList();
            var list = new List<Ec2Instance>();
            foreach (var record in list1)
            {
                if (!list.contains(record.InstanceId,record.Region))
                {
                    list.Add(record);
                }
            }
            return list;
        }



        private Ec2Instance generateEc2InstanceModel(string Ec2InstanceId, List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageTypeEventRecords,
                                                    Ec2InstanceType ec2InstanceType)
        {
            var resourceUsageEventList = _resourceUsageEvent.generateUsageList(parsedEc2ResourceUsageTypeEventRecords, Ec2InstanceId,ec2InstanceType.Region);

            Ec2Instance ec2Instance = new Ec2Instance(Ec2InstanceId, ec2InstanceType,ec2InstanceType.Region ,resourceUsageEventList);
            return ec2Instance;
        }
    }
}