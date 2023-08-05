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
                "C:/Users/wgaur/Desktop/TestCases/TestCases/Case4/Input/Customer.csv",
                "C:/Users/wgaur/Desktop/TestCases/TestCases/Case4/Input/AWSResourceTypes.csv",
                "C:/Users/wgaur/Desktop/TestCases/TestCases/Case4/Input/AWSCustomerUsage.csv",
                "C:/Users/wgaur/Desktop/Test cases1/input/Region.csv"
            );
            //---------------- all work is done ----till here-----------------
            monthlyBills.ForEach(monthlyBill => billPrinter.PrintBill(monthlyBill, "C://Users//wgaur//Desktop//Output/"));
            Console.WriteLine("CSV files are genrated");
        }
    }
}

//"C:\Users\wgaur\Desktop\Test cases1\input\Customer.csv"