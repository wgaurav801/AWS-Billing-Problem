using BillingEngine.DomainModelGenerators;
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
            var list = new List<AggregatedMonthlyEc2Usage>();


            foreach (MonthlyEc2InstanceUsage rec in MonthlyEc2InstanceUsages)
            {
                string str = rec.Ec2InstanceType.InstanceType;
                string str1 = rec.Ec2InstanceType.Region;
                if (!list.has_element(str, str1))
                {


                    //var agregate = new AggregatedMonthlyEc2Usage();

                    var ResourceType = rec.Ec2InstanceType.InstanceType;
                    
                    var demandCost = rec.Ec2InstanceType.CostPerHourOnDemand;
                    var reserveCost = rec.Ec2InstanceType.CostPerHourReserved;
                    
                    var Region = rec.Ec2InstanceType.Region;

                    HashSet<string> fields = new HashSet<string>();
                    foreach (MonthlyEc2InstanceUsage field in MonthlyEc2InstanceUsages)
                    {
                        string a1 = field.Ec2InstanceType.InstanceType;
                        string a2 = rec.Ec2InstanceType.InstanceType;
                        string a3 = field.Ec2InstanceType.Region;
                        string a4 = rec.Ec2InstanceType.Region;

                        if ((a1 == a2) && (a3 == a4))
                        {

                            foreach(var reso in field.Usages)
                            {
                                if(reso.GetBillableHours() > 0)
                                {
                                     fields.Add(field.Ec2InstanceId);

                                }
                            }
                        }
                    }
                    var TotalResources = fields.Count;



                    var totalhoursOndemand = 0;
                    var totalhoursReserved = 0;
                    foreach (MonthlyEc2InstanceUsage record in MonthlyEc2InstanceUsages)
                    {
                        string a1 = record.Ec2InstanceType.InstanceType;
                        string a2 = rec.Ec2InstanceType.InstanceType;
                        string a3 = record.Ec2InstanceType.Region;
                        string a4 = rec.Ec2InstanceType.Region;
                        string a5 = record.BillingType;
                        if ((a1 == a2) && (a3 == a4)&&(a5=="OnDemand"))
                        {
                            var temp = record.GetTotalBillableHours() ;
                            totalhoursOndemand = totalhoursOndemand + temp;
                        }else if((a1 == a2) && (a3==a4) && (a5 == "Reserved"))
                        {
                            var temp = record.GetTotalBillableHours();
                            totalhoursReserved = totalhoursReserved + temp;
                        }
                    }

                    var billed_time = new TimeSpan(totalhoursOndemand+totalhoursReserved, 0, 0);

                    var BilledUsed_hoursOnDemand = 0;
                    var BilledUsed_hoursReserved = 0;

                    foreach (MonthlyEc2InstanceUsage record in MonthlyEc2InstanceUsages)
                    {
                        string a1 = record.Ec2InstanceType.InstanceType;
                        string a2 = rec.Ec2InstanceType.InstanceType;
                        string a3 = record.Ec2InstanceType.Region;
                        string a4 = rec.Ec2InstanceType.Region;
                        string a5 = record.BillingType;
                        if ((a1 == a2) && (a3 == a4) && (a5 == "OnDemand"))
                        {
                            var temp = record.GetTotalBillableHours() - record.DiscountedHours;
                            BilledUsed_hoursOnDemand = BilledUsed_hoursOnDemand + temp;
                        }
                        else if ((a1 == a2) && (a3 == a4) && (a5 == "Reserved"))
                        {
                            var temp = record.GetTotalBillableHours();
                            BilledUsed_hoursReserved = BilledUsed_hoursReserved + temp;
                        }
                    }

                    //agregate.TotalBilledTime = billed_time;

                    var used_time = new TimeSpan(0, 0, 0);
                    foreach (MonthlyEc2InstanceUsage record in MonthlyEc2InstanceUsages)
                    {
                        if ((record.Ec2InstanceType.InstanceType == rec.Ec2InstanceType.InstanceType) && (record.Ec2InstanceType.Region == rec.Ec2InstanceType.Region))
                        {
                            foreach (ResourceUsageEvent time in record.Usages)
                            {
                                var temp1 = time.GetUsedTime();
                                used_time = used_time + temp1;
                            }
                        }
                    }

                    var TotalUsedTime = used_time;

                    var totalAmount = (totalhoursOndemand * demandCost) + (totalhoursReserved* reserveCost);
                    var actual_amount = (BilledUsed_hoursOnDemand* demandCost) +(BilledUsed_hoursReserved*reserveCost);
                    var totalDiscount = totalAmount - actual_amount;

                    var Obj = new AggregatedMonthlyEc2Usage(ResourceType, TotalResources, billed_time, TotalUsedTime, totalAmount, actual_amount, totalDiscount, Region);
                    list.Add(Obj);
                }

            }


            return list;
            //Using MonthlyEc2InstanceUsages, compute List<AggregatedMonthlyEc2Usage>
        }


        public void ApplyDiscount(string ec2InstanceId, int discountedHours)
        {
            //Find matching object of type MonthlyEc2InstanceUsage from MonthlyEc2InstanceUsages
            // and then call monthlyEc2InstanceUsage.ApplyDiscount(discountedHours)
        }

        public double GetTotalAmount(List<AggregatedMonthlyEc2Usage> list)
        {
            double totalAmount = 0.0;
            foreach (var rec in list)
            {
                totalAmount += rec.TotalAmount;
            }

            return totalAmount;
        }

        public double GetActualAmount(List<AggregatedMonthlyEc2Usage> list)
        {
            double actualAmount = 0.0;
            foreach (var rec in list)
            {
                actualAmount += rec.ActualAmount;
            }

            return actualAmount;
        }

        public double GetTotalDiscount()
        {
            throw new System.NotImplementedException();
        }

        //public double GetAmountToBePaid()
        //{
        //    return GetTotalAmount() - GetTotalDiscount();
        //}

        public List<MonthlyEc2InstanceUsage> GetFreeTierEligibleInstanceUsagesOfType(string operatingSystem)
        {

            var sc = MonthlyEc2InstanceUsages
                .Where(instanceUsage => instanceUsage.Ec2InstanceType.IsFreeTierEligible)
                .Where(instanceUsage => instanceUsage.OS == operatingSystem)
                .ToList();
            return MonthlyEc2InstanceUsages
                .Where(instanceUsage => instanceUsage.Ec2InstanceType.IsFreeTierEligible)
                .Where(instanceUsage => instanceUsage.OS == operatingSystem)
                .ToList();
        }
    }
}