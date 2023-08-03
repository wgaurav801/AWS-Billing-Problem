using BillingEngine.Models.Billing;

namespace BillingEngine.Printers
{
    public class BillPrinter
    {
        public string PrintBill(MonthlyBill monthlyBill, string pathToOutputDir)
        {
            //This method will just print the bill by generating CSV and returns file path of that csv.
            // Print header information like customer name, month, year and then print
            // monthlyBill.GetTotalAmount();
            // monthlyBill.GetTotalDiscount();
            // monthlyBill.GetAmountToBePaid();
            
            //Now print itemized bill
            monthlyBill.GetAggregatedMonthlyEc2Usages().ForEach(PrintBillItem);
            
            //Return path of generated CSV
            return null;
        }

        private void PrintBillItem(AggregatedMonthlyEc2Usage aggregatedMonthlyEc2Usage)
        {
            throw new System.NotImplementedException();
        }
    }
}