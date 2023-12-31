using BillingEngine.Parsers.Models;
using CsvHelper;
using System.Globalization;

namespace BillingEngine.Parsers
{
    public class Ec2RegionCsvParser
    {
        public List<ParsedEc2Region> Parse(string regionPath)
        {
            using (var reader = new StreamReader(regionPath))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))

                return csv.GetRecords<ParsedEc2Region>().ToList();
        }
    }
}