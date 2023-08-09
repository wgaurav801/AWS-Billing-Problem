using BillingEngine.DomainModelGenerators;
using BillingEngine.Models.Billing;
using System.Globalization;
using System.Text;

namespace BillingEngine.Printers
{
    public class BillPrinter
    {
        public string PrintBill(MonthlyBill monthlyBill, string pathToOutputDir)
        {
            var bill1 = monthlyBill.GetAggregatedMonthlyEc2Usages();
            double total_bill = monthlyBill.GetTotalAmount(bill1);
            if (total_bill == 0) { return null; }
            string ABRmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(monthlyBill.MonthYear.Month).ToUpper();
            string fullmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthlyBill.MonthYear.Month); ;

            string FileName = monthlyBill.CustomerId + "_" + ABRmonth + "-" + monthlyBill.MonthYear.Year;

            var csv = new StringBuilder();
            string csvPath = pathToOutputDir + FileName + ".csv";

            csv.AppendLine(monthlyBill.CustomerName);
            csv.AppendLine(string.Format("Bill for month of {0} {1}", fullmonth, monthlyBill.MonthYear.Year));
            csv.AppendLine(string.Format("Total Amount: ${0}",Math.Round(total_bill,4)));
            csv.AppendLine(string.Format("Total Discount: ${0}",Math.Round(total_bill - monthlyBill.GetActualAmount(bill1),4)));
            csv.AppendLine(string.Format("Actual Amount: ${0}",Math.Round(monthlyBill.GetActualAmount(bill1),4)));
            csv.AppendLine("Region,Resource Type,Total Resources,Total Used Time (HH:mm:ss),Total Billed Time (HH:mm:ss),Total Amount,Discount,Actual amount");

            foreach (var rec in bill1)
            {
                if (!(rec.TotalAmount == 0))
                    csv.AppendLine(string.Format("{0},{1},{2},{3},{4},${5},${6},${7}",
                        rec.Region,
                        rec.ResourceType,
                        rec.TotalResources,
                        DomainModelGeneratorExtensions.get_hours(rec.TotalUsedTime),
                        DomainModelGeneratorExtensions.get_hours(rec.TotalBilledTime),
                        Math.Round(rec.TotalAmount, 4),
                        Math.Round(rec.TotalDiscount,4),
                        Math.Round(rec.ActualAmount,4)
                        ));
            }
            File.WriteAllText(csvPath, csv.ToString());
            return "okk";
        }

        private void PrintBillItem(AggregatedMonthlyEc2Usage aggregatedMonthlyEc2Usage)
        {
            Console.Write(aggregatedMonthlyEc2Usage.ResourceType +
                          " - " + aggregatedMonthlyEc2Usage.TotalResources +
                          " - " + aggregatedMonthlyEc2Usage.TotalBilledTime +
                          " - " + aggregatedMonthlyEc2Usage.TotalUsedTime +
                          " - " + aggregatedMonthlyEc2Usage.TotalBilledTime +
                          " - " + aggregatedMonthlyEc2Usage.TotalAmount
                          );
            Console.WriteLine(" hiii");

        }
    }
}