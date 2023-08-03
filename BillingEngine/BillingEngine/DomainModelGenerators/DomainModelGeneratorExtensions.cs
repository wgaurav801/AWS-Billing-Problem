using System;
using System.Collections.Generic;
using System.Linq;
using BillingEngine.Models;
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
            return parsedEc2ResourceUsageEventRecords
                .Where(record => record.CustomerId == customerId)
                .ToList();
        }

        public static bool checkmonthyear(this List<MonthYear> monthYears,int month,int year)
        {
            foreach(MonthYear monthYear in monthYears)
            {
                if (monthYear.Year == year && monthYear.Month==month) { 
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