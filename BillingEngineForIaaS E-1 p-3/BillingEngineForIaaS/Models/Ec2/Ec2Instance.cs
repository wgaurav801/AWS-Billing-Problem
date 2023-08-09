using BillingEngine.Models.Billing;

namespace BillingEngine.Models.Ec2
{
    public class Ec2Instance
    {
        public string InstanceId { get; }

        public Ec2InstanceType InstanceType { get; }

        public string Region { get; }

        public List<ResourceUsageEvent> Usages { get; }

        public string OS;
        public string BillingType { get; }

        public Ec2Instance(string instanceId, Ec2InstanceType instanceType, string Region, List<ResourceUsageEvent> usages, string OS, string billingType)
        {
            InstanceId = instanceId;
            InstanceType = instanceType;
            this.Region = Region;
            Usages = usages;
            this.OS = OS;
            BillingType = billingType;
        }





        public MonthlyEc2InstanceUsage GetMonthlyEc2InstanceUsageForMonth(MonthYear monthYear)
        {

            MonthlyEc2InstanceUsage Obj = new MonthlyEc2InstanceUsage(InstanceId, InstanceType, OS, BillingType);
            var eventlist = new List<ResourceUsageEvent>();
            foreach (var e in Usages)
            {
                int usedfrom = e.UsedFrom.Year * 100 + e.UsedFrom.Month;
                int useduntil = e.UsedUntil.Year * 100 + e.UsedUntil.Month;
                int currentevent = monthYear.Year * 100 + monthYear.Month;
                if (usedfrom <= currentevent && currentevent <= useduntil)
                    eventlist.Add(getrecord(e.UsedFrom, e.UsedUntil, monthYear));
            }

            foreach (ResourceUsageEvent reco in eventlist) Obj.AddEc2UsageEvent(reco);

            return Obj;
        }

        private ResourceUsageEvent getrecord(DateTime UsedFrom, DateTime UsedUntil, MonthYear monthYear)
        {
            int usedfrom = UsedFrom.Year * 100 + UsedFrom.Month;
            int useduntil = UsedUntil.Year * 100 + UsedUntil.Month;
            int currentevent = monthYear.Year * 100 + monthYear.Month;
            if (usedfrom == useduntil && usedfrom == currentevent)
            {
                return new ResourceUsageEvent(UsedFrom, UsedUntil);
            }
            else if (usedfrom < currentevent && currentevent < useduntil)
            {
                if (monthYear.Month == 12)
                {
                    DateTime start = new DateTime(monthYear.Year, monthYear.Month, 01, 00, 00, 00);
                    DateTime end = new DateTime(monthYear.Year + 1, 01, 01, 00, 00, 00);
                    return new ResourceUsageEvent(start, end);
                }
                else
                {
                    DateTime start = new DateTime(monthYear.Year, monthYear.Month, 01, 00, 00, 00);
                    DateTime end = new DateTime(monthYear.Year, monthYear.Month + 1, 01, 00, 00, 00);
                    return new ResourceUsageEvent(start, end);
                }
            }
            else if (usedfrom == currentevent && currentevent < useduntil)
            {
                if (monthYear.Month == 12)
                {
                    DateTime start = UsedFrom;
                    DateTime end = new DateTime(monthYear.Year + 1, 01, 01, 00, 00, 00);
                    return new ResourceUsageEvent(start, end);
                }
                else
                {
                    DateTime start = UsedFrom;
                    DateTime end = new DateTime(monthYear.Year, monthYear.Month + 1, 01, 00, 00, 00);
                    return new ResourceUsageEvent(start, end);
                }
            }
            else if (usedfrom < currentevent && currentevent == useduntil)
            {
                DateTime start = new DateTime(monthYear.Year, UsedUntil.Month, 01, 00, 00, 00);
                DateTime end = UsedUntil;
                return new ResourceUsageEvent(start, end);
            }
            return null;

        }

        public DateTime GetMinimumValueOfUsedFrom()
        {
            return Usages.Select(usage => usage.UsedFrom).Min();
        }
    }
}