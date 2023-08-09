namespace BillingEngine.Models.Ec2
{
    public class Ec2InstanceType
    {
        public string InstanceType { get; }
        public double CostPerHourOnDemand { get; }
        public double CostPerHourReserved { get; }
        public string Region { get; }
        // public string OperatingSystem { get; set; }
        //public BillingType BillingType { get; }
        public bool IsFreeTierEligible { get; }
        Ec2InstanceType() { }


        public Ec2InstanceType(string InstanceType,
                        double CostPerHourOnDemand, double CostPerHourReserved, string Region,
                        bool val)
        {
            this.InstanceType = InstanceType;
            this.CostPerHourOnDemand = CostPerHourOnDemand;
            this.CostPerHourReserved = CostPerHourReserved;
            this.Region = Region;
            IsFreeTierEligible = val;

        }


    }
}