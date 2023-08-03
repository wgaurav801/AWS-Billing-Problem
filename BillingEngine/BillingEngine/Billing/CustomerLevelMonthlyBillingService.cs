using System.Collections.Generic;
using System.Linq;
using BillingEngine.Models;
using BillingEngine.Models.Billing;

namespace BillingEngine.Billing
{
    public class CustomerLevelMonthlyBillingService
    {
        private readonly DiscountService _discountService;

        public CustomerLevelMonthlyBillingService()
        {
            _discountService = new DiscountService();
        }
        
        public List<MonthlyBill> GenerateMonthlyBillsForCustomer(Customer customer)
        {
            var distinctMonthYears = customer.GetDistinctMonthYears();

            return distinctMonthYears
                .Select(monthYear => GenerateBillForMonth(customer, monthYear))
                .ToList();
        }

        private MonthlyBill GenerateBillForMonth(Customer customer, MonthYear monthYear)
        {
            var monthlyBill = new MonthlyBill(customer.CustomerId, customer.CustomerName, monthYear);

            monthlyBill.AddMonthlyEc2Usages(customer.GetMonthlyEc2InstanceUsagesForMonth(monthYear));

            _discountService.ApplyDiscounts(customer, monthlyBill);
            return monthlyBill;
        }
    }
}