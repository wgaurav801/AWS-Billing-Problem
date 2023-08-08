namespace BillingEngine.Models.Ec2
{
    public class Ec2InstanceType
    {
        public string InstanceType { get; }
        public double CostPerHour { get; }
        public string Region { get; }
        // public string OperatingSystem { get; set; }
        public BillingType BillingType { get; }
        public bool IsFreeTierEligible { get; }
        Ec2InstanceType() { }


        public Ec2InstanceType(string InstanceType,
                        double CostPerHour, string Region,
                        bool val)
        {
            this.InstanceType = InstanceType;
            this.CostPerHour = CostPerHour;
            this.Region = Region;
            BillingType = BillingType.OnDemand;
            IsFreeTierEligible = val;

        }


    }
}