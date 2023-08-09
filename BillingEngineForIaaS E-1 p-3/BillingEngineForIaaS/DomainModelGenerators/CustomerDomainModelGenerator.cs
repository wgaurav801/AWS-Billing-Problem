using BillingEngine.Models;
using BillingEngine.Models.Ec2;
using BillingEngine.Parsers;
using BillingEngine.Parsers.Models;
using BillingEngineForIaaS.DomainModelGenerators;
using BillingEngineForIaaS.Parsers.Models;

namespace BillingEngine.DomainModelGenerators
{
    public class CustomerDomainModelGenerator
    {
        private readonly Ec2InstanceTypeDomainModelGenerator _ec2InstanceTypeDomainModelGenerator;
        private readonly Ec2InstanceDomainModelGenerator _ec2InstanceDomainModelGenerator;
        private readonly Ec2RegiondomainModelGenerator _ec2RegionDomainModelGenerator;

        public CustomerDomainModelGenerator()
        {
            _ec2InstanceDomainModelGenerator = new Ec2InstanceDomainModelGenerator();
            _ec2InstanceTypeDomainModelGenerator = new Ec2InstanceTypeDomainModelGenerator();
            _ec2RegionDomainModelGenerator = new Ec2RegiondomainModelGenerator();
        }

        public List<Customer> GenerateCustomerModels(
            List<ParsedCustomerRecord> parsedCustomerRecords,
            List<ParsedEc2InstanceType> parsedEc2InstanceTypes,
            List<ParsedEc2Region> parsedEc2Regions,
            List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageEventRecords,
            List<ParsedEc2ResourceUsageReservedEventRecord> parsedEc2ResourceUsageReservedEventRecords)
        {
            List<Ec2Region> ec2Regions = _ec2RegionDomainModelGenerator.GenerateEc2Region(parsedEc2Regions);

            List<Ec2InstanceType> ec2InstanceTypes = _ec2InstanceTypeDomainModelGenerator
                .GenerateEc2InstanceTypes(parsedEc2InstanceTypes, ec2Regions);

            //Generate Ec2Region instances by defining Ec2RegionDomainModelGenerator

            //var sc = parsedCustomerRecords.Select(parsedCustomerRecord =>
            //        GenerateCustomerModel(
            //            parsedCustomerRecord,
            //            parsedEc2ResourceUsageEventRecords.FindRecordsForCustomer(parsedCustomerRecord.CustomerId),
            //            parsedEc2ResourceUsageReservedEventRecords.FindRecordsForCustomer(parsedCustomerRecord.CustomerId),
            //            ec2InstanceTypes,
            //            ec2Regions)
            //    )
            //    .ToList();

            return parsedCustomerRecords.Select(parsedCustomerRecord =>
                    GenerateCustomerModel(
                        parsedCustomerRecord,
                        parsedEc2ResourceUsageEventRecords.FindRecordsForCustomer(parsedCustomerRecord.CustomerId),
                        parsedEc2ResourceUsageReservedEventRecords.FindRecordsForCustomer(parsedCustomerRecord.CustomerId),
                        ec2InstanceTypes,
                        ec2Regions)
                )
                .ToList();
        }

        private Customer GenerateCustomerModel(
            ParsedCustomerRecord parsedCustomerRecord,
            List<ParsedEc2ResourceUsageEventRecord> ec2ResourceUsageEventsForCustomer,
            List<ParsedEc2ResourceUsageReservedEventRecord> ec2ResourceUsageReservedEventsForCustomer,
            List<Ec2InstanceType> ec2InstanceTypes,
            List<Ec2Region> ec2Regions)
        {

            var Ec2Instancelist = _ec2InstanceDomainModelGenerator.GenerateEc2InstanceModels(
                                                                                  ec2ResourceUsageEventsForCustomer,
                                                                                  ec2ResourceUsageReservedEventsForCustomer,
                                                                                  ec2InstanceTypes
                                                                                  );

            string customerId = (parsedCustomerRecord.CustomerId.Split('-'))[0] + (parsedCustomerRecord.CustomerId.Split('-'))[1];
            Customer cs = new Customer(customerId, parsedCustomerRecord.CustomerName, Ec2Instancelist);

            return cs;

            // Build customer object as well as associated composite objects, e.g. Ec2Instance, 
            //throw new System.NotImplementedException();
        }
    }
}