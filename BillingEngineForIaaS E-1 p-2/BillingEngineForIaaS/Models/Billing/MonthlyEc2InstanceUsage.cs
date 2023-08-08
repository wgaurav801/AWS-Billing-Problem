using BillingEngine.Models.Ec2;

namespace BillingEngine.Models.Billing
{
    public class MonthlyEc2InstanceUsage
    {
        public string Ec2InstanceId { get; }

        public Ec2InstanceType Ec2InstanceType { get; }

        public List<ResourceUsageEvent> Usages { get; }

        public string OS;

        public int DiscountedHours { get; private set; }

        public MonthlyEc2InstanceUsage()
        {
            Usages = new List<ResourceUsageEvent>();
        }
        public MonthlyEc2InstanceUsage(string ec2InstanceId, Ec2InstanceType ec2InstanceType, string OS)
        {
            Ec2InstanceId = ec2InstanceId;
            Ec2InstanceType = ec2InstanceType;
            Usages = new List<ResourceUsageEvent>();
            this.OS = OS;
        }


        public void AddEc2UsageEvent(ResourceUsageEvent usageEvent)
        {
            Usages.Add(usageEvent);
        }

        public void ApplyDiscount(int discountedHours)
        {
            DiscountedHours = discountedHours;
        }

        public int GetTotalBillableHours()
        {
            return Usages.Select(usage => usage.GetBillableHours()).Sum();
        }
    }
}