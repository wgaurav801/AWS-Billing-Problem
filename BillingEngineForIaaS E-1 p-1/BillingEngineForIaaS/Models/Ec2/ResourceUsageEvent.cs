using BillingEngine.Parsers.Models;

namespace BillingEngine.Models.Ec2
{
    public class ResourceUsageEvent
    {
        public DateTime UsedFrom { get; }

        public DateTime UsedUntil { get; }

        public ResourceUsageEvent()
        {

        }
        public ResourceUsageEvent(DateTime UsedFrom, DateTime UsedUntil)
        {
            this.UsedFrom = UsedFrom;
            this.UsedUntil = UsedUntil;
        }

        public int GetBillableHours()
        {
            var usedHours = (UsedUntil - UsedFrom).TotalHours;
            return Convert.ToInt32(Math.Ceiling(usedHours));
        }

        public TimeSpan GetUsedTime()
        {
            var used_time = UsedUntil.Subtract(UsedFrom).TotalSeconds;
            var used_hours = Convert.ToInt32(Math.Floor(used_time / 3600));
            used_time = used_time % 3600;
            var used_minutes = Convert.ToInt32(Math.Floor(used_time / 60));
            used_time= used_time % 60;
            var used_second = Convert.ToInt32(Math.Floor(used_time));
            


            return new TimeSpan(used_hours, used_minutes, used_second);
        }


        public List<ResourceUsageEvent> generateUsageList(List<ParsedEc2ResourceUsageEventRecord> parsedEc2ResourceUsageTypeEventRecords
                                                          , string InstanceId)
        {
            var rc = parsedEc2ResourceUsageTypeEventRecords
                .Where(record => record.Ec2InstanceId == InstanceId)
                .Select(rec => generateUsage(rec.UsedFrom, rec.UsedUntil))
                .ToList();
            return rc;
        }


        private ResourceUsageEvent generateUsage(DateTime UsedFrom, DateTime UsedUntil)
        {
            ResourceUsageEvent rc = new ResourceUsageEvent(UsedFrom, UsedUntil);
            return rc;
        }

    }
}