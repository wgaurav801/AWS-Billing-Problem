namespace BillingEngine.Models.Ec2
{
    public class Ec2InstanceType
    {
        public string InstanceType { get; }
        public double CostPerHour { get; }
        public string Region { get; }
        public OperatingSystem OperatingSystem { get; }
        public BillingType BillingType { get; }
        public bool IsFreeTierEligible { get; }
        Ec2InstanceType() { }


        public Ec2InstanceType(string InstanceType,
                        double CostPerHour, string Region
                        )
        {
            this.InstanceType = InstanceType;
            this.CostPerHour = CostPerHour;
            this.Region = Region;
            OperatingSystem = OperatingSystem.Windows;
            BillingType = BillingType.OnDemand;
            this.IsFreeTierEligible = false;

        }
    }
}