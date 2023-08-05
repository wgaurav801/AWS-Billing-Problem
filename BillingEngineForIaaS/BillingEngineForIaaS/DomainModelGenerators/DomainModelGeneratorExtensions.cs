using BillingEngine.Models;
using BillingEngine.Models.Billing;
using BillingEngine.Models.Ec2;
using BillingEngine.Parsers.Models;

namespace BillingEngine.DomainModelGenerators
{
    public static class DomainModelGeneratorExtensions
    {
        // This is an extension method (used to extend the functionality of some existing class)
        public static List<ParsedEc2ResourceUsageEventRecord> FindRecordsForCustomer(
            this List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageEventRecords,
            string customerId)
        {
            customerId = customerId.Split('-')[0] + customerId.Split('-')[1];
            return parsedEc2ResourceUsageEventRecords
                .Where(record => record.CustomerId == customerId)
                .ToList();
        }

        public static bool checkmonthyear(this List<MonthYear> monthYears, int month, int year)
        {
            foreach (MonthYear monthYear in monthYears)
            {
                if (monthYear.Year == year && monthYear.Month == month)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool has_element(this List<AggregatedMonthlyEc2Usage> list, string str)
        {
            foreach (var item in list)
            {
                if (item.ResourceType == str)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(this List<Ec2Instance> list , string str)
        {
            foreach(var item in list)
            {
                if (item.InstanceId.Equals(str))
                {
                    return true;
                }
                
            }
            return false;
        }
        //public static List<ParsedEc2ResourceUsageEventRecord> FindRecordsForInstance(
        //    this List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageEventRecords,
        //    string Ec2InstanceId)
        //{
        //    return parsedEc2ResourceUsageEventRecords.Where(record => record.Ec2InstanceId == Ec2InstanceId).ToList();
        //}
    }
}