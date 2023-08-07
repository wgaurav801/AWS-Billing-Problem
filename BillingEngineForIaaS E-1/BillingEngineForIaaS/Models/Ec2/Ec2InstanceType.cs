namespace BillingEngine.Models.Ec2
{
    public class Ec2InstanceType
    {
        public string InstanceType { get; }
        public double CostPerHour { get; }
        public Ec2Region Region { get; }
        public OperatingSystem OperatingSystem { get; }
        public BillingType BillingType { get; }
        public bool IsFreeTierEligible { get; }
        Ec2InstanceType() { }


        public Ec2InstanceType(string InstanceType,
                        double CostPerHour
                        )
        {
            this.InstanceType = InstanceType;
            this.CostPerHour = CostPerHour;
            Region = new Ec2Region("US");
            OperatingSystem = OperatingSystem.Windows;
            BillingType = BillingType.OnDemand;
            this.IsFreeTierEligible = false;

        }
    }
}