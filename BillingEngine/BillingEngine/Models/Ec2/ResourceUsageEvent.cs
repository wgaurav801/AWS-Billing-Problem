using BillingEngine.Parsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var usedHours = UsedUntil.Subtract(UsedFrom).TotalHours;
            return Convert.ToInt32(Math.Ceiling(usedHours));
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
            ResourceUsageEvent rc= new ResourceUsageEvent(UsedFrom, UsedUntil);
            return rc;
        }

    }
}