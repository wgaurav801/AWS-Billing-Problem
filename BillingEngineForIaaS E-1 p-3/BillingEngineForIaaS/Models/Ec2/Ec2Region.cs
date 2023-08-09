namespace BillingEngine.Models.Ec2
{
    public class Ec2Region
    {
        public string Name { get; }

        public string FreeTierEligibleInstanceType { get; }
        public Ec2Region(string Name, string freeTierEligibleInstanceType)
        {
            this.Name = Name;
            FreeTierEligibleInstanceType = freeTierEligibleInstanceType;
        }
    }
}