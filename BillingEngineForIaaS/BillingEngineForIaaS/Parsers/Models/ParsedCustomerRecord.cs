using CsvHelper.Configuration.Attributes;

namespace BillingEngine.Parsers
{
    public class ParsedCustomerRecord
    {
        [Name("Customer ID")]
        public string CustomerId { get; set; }
        [Name("Customer Name")]
        public string CustomerName { get; set; }
    }
}