using BillingEngine.Models.Billing;

namespace BillingEngine.Models.Ec2
{
    public class Ec2Instance
    {
        public string InstanceId { get; }

        public Ec2InstanceType InstanceType { get; }

        public string Region { get; }



        public List<ResourceUsageEvent> Usages { get; }

        public Ec2Instance(string instanceId, Ec2InstanceType instanceType, string Region, List<ResourceUsageEvent> usages)
        {
            InstanceId = instanceId;
            InstanceType = instanceType;
            this.Region = Region;
            Usages = usages;
        }

        public MonthlyEc2InstanceUsage GetMonthlyEc2InstanceUsageForMonth(MonthYear monthYear)
        {

            MonthlyEc2InstanceUsage Obj = new MonthlyEc2InstanceUsage(InstanceId, InstanceType);
            var eventlist = new List<ResourceUsageEvent>();
            foreach (var e in Usages)
            {
                int usedfrom = e.UsedFrom.Year * 100 + e.UsedFrom.Month;
                int useduntil = e.UsedUntil.Year * 100 + e.UsedUntil.Month;
                int currentevent = monthYear.Year * 100 + monthYear.Month;
                if (usedfrom <= currentevent && currentevent <= useduntil)
                    eventlist.Add(getrecord(e.UsedFrom, e.UsedUntil, monthYear));
            }

            //var evnetlist = Usages.Select(rec => getrecord(rec.UsedFrom, rec.UsedUntil, monthYear)).ToList();

            foreach (ResourceUsageEvent reco in eventlist)
            {

                Obj.AddEc2UsageEvent(reco);
            }
            //foreach (ResourceUsageEvent it in Obj.Usages)
            //{
            //    Console.WriteLine(it.ToString());
            //}

            // Creates an instance of MonthlyEc2InstanceUsage by capturing usage events, applicable for a given month and year
            // For example, if Usages contain
            // 2021-05-10 to 2021-05-12 and
            // 2021-05-15 to 2021-05-17 and
            // 2021-05-25 to 2021-06-04 and
            // 2021-06-15 to 2021-06-17

            // Then newly constructed MonthlyEc2InstanceUsage for month 05/2021 (passed as argument) would include
            // 2021-05-10 to 2021-05-12 and
            // 2021-05-15 to 2021-05-17 and
            // 2021-05-25 to 2021-05-31
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