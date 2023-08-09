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

        public static bool has_element(this List<AggregatedMonthlyEc2Usage> list, string type,string region)
        {
            foreach (var item in list)
            {
                if ((item.ResourceType == type)&&(item.Region  == region))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(this List<Ec2Instance> list, string str,string region)
        {
            foreach (var item in list)
            {
                if (item.InstanceId.Equals(str)&& item.Region == region)
                {
                    return true;
                }

            }
            return false;
        }

        public static string get_hours(TimeSpan time)
        {
            var used_time = time.TotalSeconds;
            var used_hours = Convert.ToInt32(Math.Floor(used_time / 3600));
            used_time = used_time % 3600;
            var used_minutes = Convert.ToInt32(Math.Floor(used_time / 60));
            used_time = used_time % 60;
            var used_second = Convert.ToInt32(Math.Floor(used_time));

            return used_hours.ToString() + ":" + used_minutes.ToString() + ":" + used_second.ToString();
        }

        //public static List<ParsedEc2ResourceUsageEventRecord> FindRecordsForInstance(
        //    this List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageEventRecords,
        //    string Ec2InstanceId)
        //{
        //    return parsedEc2ResourceUsageEventRecords.Where(record => record.Ec2InstanceId == Ec2InstanceId).ToList();
        //}
    }
}