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
                foreach (var rec in item.Usages)
                {
                    int diff = rec.UsedUntil.Month - rec.UsedFrom.Month + (rec.UsedUntil.Year - rec.UsedFrom.Year) * 12;
                    for (int i = 0; i <= diff; i++)
                    {
                        int month = rec.UsedFrom.Month;
                        int year = rec.UsedFrom.Year;
                        if (!sl.checkmonthyear(month, year))
                        {
                            MonthYear Obj = new MonthYear(month, year);
                            sl.Add(Obj);

                        }
                        if (month == 12)
                        {
                            month = 1;
                            year++;
                        }
                        else { month++; }   
                    }
                }
            }
            return sl;
        }

        public List<MonthlyEc2InstanceUsage> GetMonthlyEc2InstanceUsagesForMonth(MonthYear monthYear)
        {
            //List<MonthlyEc2InstanceUsage> list = new List<MonthlyEc2InstanceUsage>();
            var list = Ec2Instances.Select(rec => rec.GetMonthlyEc2InstanceUsageForMonth(monthYear)).ToList();
            // Using List<Ec2Instance> , construct  List<MonthlyEc2InstanceUsage>
            // by calling ec2Instance.GetUsageInMonth(monthYear)
            return list;
        }

        public DateTime GetJoiningDate()
        {
            return Ec2Instances
                .Select(instance => instance.GetMinimumValueOfUsedFrom())
                .Min();
        }
    }
}