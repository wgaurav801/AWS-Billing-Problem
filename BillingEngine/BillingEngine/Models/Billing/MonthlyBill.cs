using System.Collections.Generic;
using System.Linq;
using BillingEngine.Billing;
using BillingEngine.Models.Ec2;

namespace BillingEngine.Models.Billing
{
    public class MonthlyBill
    {
        public string CustomerId { get; }
        public string CustomerName { get; }

        public MonthYear MonthYear { get; }
        
        public List<MonthlyEc2InstanceUsage> MonthlyEc2InstanceUsages { get; }

        public MonthlyBill(string customerId, string customerName, MonthYear monthYear)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            MonthYear = monthYear;
            MonthlyEc2InstanceUsages = new List<MonthlyEc2InstanceUsage>();
        }

        public void AddMonthlyEc2Usages(List<MonthlyEc2InstanceUsage> monthlyEc2InstanceUsages)
        {
            MonthlyEc2InstanceUsages.AddRange(monthlyEc2InstanceUsages);
        }

        public List<AggregatedMonthlyEc2Usage> GetAggregatedMonthlyEc2Usages()
        {
            //Using MonthlyEc2InstanceUsages, compute List<AggregatedMonthlyEc2Usage>
            return new List<AggregatedMonthlyEc2Usage>();
        }

        public void ApplyDiscount(string ec2InstanceId, int discountedHours)
        {
            //Find matching object of type MonthlyEc2InstanceUsage from MonthlyEc2InstanceUsages
            // and then call monthlyEc2InstanceUsage.ApplyDiscount(discountedHours)
        }

        public double GetTotalAmount()
        {
            throw new System.NotImplementedException();
        }

        public double GetTotalDiscount()
        {
            throw new System.NotImplementedException();
        }

        public double GetAmountToBePaid()
        {
            return GetTotalAmount() - GetTotalDiscount();
        }

        public List<MonthlyEc2InstanceUsage> GetFreeTierEligibleInstanceUsagesOfType(OperatingSystem operatingSystem)
        {
            return MonthlyEc2InstanceUsages
                .Where(instanceUsage => instanceUsage.Ec2InstanceType.IsFreeTierEligible)
                .Where(instanceUsage => instanceUsage.Ec2InstanceType.OperatingSystem == operatingSystem)
                .ToList();
        }
    }
}