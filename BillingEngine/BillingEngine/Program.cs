using BillingEngine.Billing;
using BillingEngine.Printers;

namespace BillingEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingService billingService = new BillingService();
            BillPrinter billPrinter = new BillPrinter();

            var monthlyBills = billingService.GenerateMonthlyBills(
                "C:/Users/wgaur/Desktop/TestCases/TestCases/Case1/Input/Customer.csv",
                "C:/Users/wgaur/Desktop/TestCases/TestCases/Case1/Input/AWSResourceTypes.csv",
                "C:/Users/wgaur/Desktop/TestCases/TestCases/Case1/Input/AWSCustomerUsage.csv",
                "C:/Users/wgaur/Desktop/Test cases1/input/Region.csv"
            );

            monthlyBills.ForEach(monthlyBill => billPrinter.PrintBill(monthlyBill, "path/to/output/dir"));
        }
    }
}

//"C:\Users\wgaur\Desktop\Test cases1\input\Customer.csv"