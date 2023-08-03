using System;
using System.Collections.Generic;
using System.Linq;
using BillingEngine.DomainModelGenerators;
using BillingEngine.Models.Billing;
using BillingEngine.Models.Ec2;

namespace BillingEngine.Models
{
    public class Customer
    {
        public string CustomerId { get; }
        public string CustomerName { get; }
        
        public List<Ec2Instance> Ec2Instances { get; }

        public Customer()
        {
            Ec2Instances = new List<Ec2Instance>();
        }

        public Customer(string customerId, string customerName, List<Ec2Instance> ec2Instances)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Ec2Instances = ec2Instances;
        }

        public List<MonthYear> GetDistinctMonthYears()
        {
            List<MonthYear> sl = new List<MonthYear>();

            foreach (var item in Ec2Instances)
            {
                foreach (var rec in item.Usages) {
                    if (!sl.checkmonthyear(rec.UsedFrom.Month,rec.UsedFrom.Year))
                    {
                        MonthYear Obj = new MonthYear(rec.UsedFrom.Month, rec.UsedFrom.Year);
                        sl.Add(Obj);
                        
                    }
                }
            }
            
            return sl;
        }

        public List<MonthlyEc2InstanceUsage> GetMonthlyEc2InstanceUsagesForMonth(MonthYear monthYear)
        {
            // Using List<Ec2Instance> , construct  List<MonthlyEc2InstanceUsage>
            // by calling ec2Instance.GetUsageInMonth(monthYear)
            return new List<MonthlyEc2InstanceUsage>();
        }

        public DateTime GetJoiningDate()
        {
            return Ec2Instances
                .Select(instance => instance.GetMinimumValueOfUsedFrom())
                .Min();
        }
    }
}