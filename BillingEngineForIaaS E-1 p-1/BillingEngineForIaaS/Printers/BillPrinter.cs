using BillingEngine.Models.Billing;
using System.Globalization;
using System;
using System.Text;
using BillingEngine.DomainModelGenerators;

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
            double total_bill = monthlyBill.GetTotalAmount(bill1) ;
            if (total_bill == 0) { return null; }
            string ABRmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(monthlyBill.MonthYear.Month).ToUpper();
            string fullmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthlyBill.MonthYear.Month); ;

            string FileName = monthlyBill.CustomerId + "_" + ABRmonth + "-" + monthlyBill.MonthYear.Year;

            var csv = new StringBuilder();
            string csvPath = pathToOutputDir + FileName + ".csv";

            csv.AppendLine(monthlyBill.CustomerName);
            csv.AppendLine(string.Format("Bill for month of {0} {1}", fullmonth, monthlyBill.MonthYear.Year));
            csv.AppendLine(string.Format("Total Amount: ${0}", total_bill));
            csv.AppendLine("Resource Type,Region,Total Resources,Total Used Time (HH:mm:ss),Total Billed Time (HH:mm:ss),Rate (per hour),Total Amount");

            foreach (var rec in bill1)
            {
                if(!(rec.TotalAmount==0))
                csv.AppendLine(string.Format("{0},{1},{2},{3},{4},${5},${6}",
                    rec.ResourceType,
                    rec.Region,
                    rec.TotalResources,
                    DomainModelGeneratorExtensions.get_hours(rec.TotalUsedTime),
                    DomainModelGeneratorExtensions.get_hours(rec.TotalBilledTime),
                    rec.cost,
                    Math.Round(rec.TotalAmount, 4)
                    ));
            }
            File.WriteAllText(csvPath, csv.ToString());

            // monthlyBill.GetAggregatedMonthlyEc2Usages().ForEach(PrintBillItem);

            //Return path of generated CSV
            return "okk";
        }

        private void PrintBillItem(AggregatedMonthlyEc2Usage aggregatedMonthlyEc2Usage)
        {
            Console.Write(aggregatedMonthlyEc2Usage.ResourceType+
                          " - "+aggregatedMonthlyEc2Usage.TotalResources+
                          " - "+aggregatedMonthlyEc2Usage.TotalBilledTime+
                          " - "+aggregatedMonthlyEc2Usage.TotalUsedTime+
                          " - "+aggregatedMonthlyEc2Usage.cost+
                          " - "+aggregatedMonthlyEc2Usage.TotalAmount
                          );
            Console.WriteLine(" hiii");

        }
    }
}