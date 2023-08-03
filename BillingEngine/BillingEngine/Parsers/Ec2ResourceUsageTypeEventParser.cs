using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BillingEngine.Parsers.Models;
using CsvHelper;

namespace BillingEngine.Parsers
{
    public class Ec2ResourceUsageTypeEventParser
    {

        public List<ParsedEc2ResourceUsageEventRecord> Parse(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture)) 

            
            return csv.GetRecords<ParsedEc2ResourceUsageEventRecord>().ToList(); ;
        }
    }
}