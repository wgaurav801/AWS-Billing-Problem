using BillingEngine.Models.Billing;

namespace BillingEngine.Printers
{
    public class BillPrinter
    {
        public string PrintBill(MonthlyBill monthlyBill, string pathToOutputDir)
        {
            //This method will just print the bill by generating CSV and returns file path of that csv.
            // Print header information like customer name, month, year and then print
            //monthlyBill.GetTotalAmount();
            // monthlyBill.GetTotalDiscount();
            // monthlyBill.GetAmountToBePaid();

            //Now print itemized bill
            var bill1 = monthlyBill.GetAggregatedMonthlyEc2Usages();
            foreach (var bill in monthlyBill.GetAggregatedMonthlyEc2Usages())
            {
                Console.Write(bill.ResourceType);
                              Console.Write(bill.TotalResources);
                              Console.Write(bill.TotalBilledTime);
                Console.Write(bill.TotalUsedTime);
                Console.Write(bill.cost);
                Console.Write(bill.TotalAmount);
                          
                Console.WriteLine("okk");
            }
           // monthlyBill.GetAggregatedMonthlyEc2Usages().ForEach(PrintBillItem);

            //Return path of generated CSV
            return "okk";
        }

        private void PrintBillItem(AggregatedMonthlyEc2Usage aggregatedMonthlyEc2Usage)
        {
            Console.Write(aggregatedMonthlyEc2Usage.ResourceType,
                          aggregatedMonthlyEc2Usage.TotalResources,
                          aggregatedMonthlyEc2Usage.TotalBilledTime,
                          aggregatedMonthlyEc2Usage.TotalUsedTime,
                          aggregatedMonthlyEc2Usage.cost,
                          aggregatedMonthlyEc2Usage.TotalAmount
                          );
            
        }
    }
}