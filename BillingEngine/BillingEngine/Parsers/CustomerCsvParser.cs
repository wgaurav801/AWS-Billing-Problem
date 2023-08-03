using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

namespace BillingEngine.Parsers
{
    public class CustomerCsvParser
    {
        public List<ParsedCustomerRecord> Parse(string filePath)
        {
            // Your logic about parsing the Customer CSV
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))

                return csv.GetRecords<ParsedCustomerRecord>().ToList();
        }
    }
}