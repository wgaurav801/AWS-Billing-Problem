using System;
using System.Collections.Generic;
using System.Linq;
using BillingEngine.Models.Billing;

namespace BillingEngine.Models.Ec2
{
    public class Ec2Instance
    {
        public string InstanceId { get; }
        
        public Ec2InstanceType InstanceType { get; }

        public List<ResourceUsageEvent> Usages { get; }

        public Ec2Instance(string instanceId, Ec2InstanceType instanceType, List<ResourceUsageEvent> usages)
        {
            InstanceId = instanceId;
            InstanceType = instanceType;
            Usages = usages;
        }

        public MonthlyEc2InstanceUsage GetMonthlyEc2InstanceUsageForMonth(MonthYear monthYear)
        {
            // Creates an instance of MonthlyEc2InstanceUsage by capturing usage events, applicable for a given month and year
            // For example, if Usages contain
            // 2021-05-10 to 2021-05-12 and
            // 2021-05-15 to 2021-05-17 and
            // 2021-05-25 to 2021-06-04 and
            // 2021-06-15 to 2021-06-17
            
            // Then newly constructed MonthlyEc2InstanceUsage for month 05/2021 (passed as argument) would include
            // 2021-05-10 to 2021-05-12 and
            // 2021-05-15 to 2021-05-17 and
            // 2021-05-25 to 2021-05-31
            return null;
        }

        public DateTime GetMinimumValueOfUsedFrom()
        {
            return Usages.Select(usage => usage.UsedFrom).Min();
        }
    }
}