namespace BillingEngine.Models.Billing
{
    public class AggregatedMonthlyEc2Usage
    {
        public string ResourceType { get; }
        public string Region { get; }
        public double cost { get; }
        public int TotalResources { get; }

        public TimeSpan TotalBilledTime { get; }
        public TimeSpan TotalUsedTime { get; }
        public TimeSpan TotalDiscountedTime { get; }

        public double TotalAmount { get; }
        public double TotalDiscount { get; }

        public double ActualAmount { get; }

        public double GetActualAmountToBePaid()
        {
            return TotalAmount - TotalDiscount;
        }

        public AggregatedMonthlyEc2Usage() { }
        public AggregatedMonthlyEc2Usage(string ResourceType, double cost, int TotalResources, TimeSpan TotalBilledTime, TimeSpan TotalUsedTime,
                                          double TotalAmount,double actualAmount, double TotalDiscount,string Region)
        {
            this.ResourceType = ResourceType;
            this.cost = cost;
            this.TotalResources = TotalResources;
            this.TotalBilledTime = TotalBilledTime;
            this.TotalUsedTime = TotalUsedTime;
            this.TotalAmount = TotalAmount;
            this.ActualAmount = actualAmount;
            this.TotalDiscount = TotalDiscount;
            this.Region = Region;
        }

    }
}