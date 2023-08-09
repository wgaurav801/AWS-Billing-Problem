using BillingEngineForIaaS.Parsers.Models;
using CsvHelper;
using System.Globalization;

namespace BillingEngineForIaaS.Parsers
{
    public class Ec2ResourceUsageReservedTypeEventParser
    {
        public List<ParsedEc2ResourceUsageReservedEventRecord> Parse(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))


                return csv.GetRecords<ParsedEc2ResourceUsageReservedEventRecord>().ToList(); ;
        }
    }
}
