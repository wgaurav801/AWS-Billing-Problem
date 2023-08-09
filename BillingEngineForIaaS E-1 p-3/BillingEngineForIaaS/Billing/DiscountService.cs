using BillingEngine.Models;
using BillingEngine.Models.Billing;

namespace BillingEngine.Billing
{
    public class DiscountService
    {
        private const int MaxFreeTierEligibleHours = 750;

        public void ApplyDiscounts(
            Customer customer,
            MonthlyBill monthlyBill)
        {
            if (monthlyBill.MonthYear.IsLesserThan(customer.GetJoiningDate().AddYears(1)))
            {
                var freeTierEligibleLinuxInstances = monthlyBill.GetFreeTierEligibleInstanceUsagesOfType("Linux");
                var freeTierEligibleWindowsInstances = monthlyBill.GetFreeTierEligibleInstanceUsagesOfType("Windows");

                DistributeFreeTierEligibleHoursAcrossInstances(
                    freeTierEligibleLinuxInstances,
                    MaxFreeTierEligibleHours);

                DistributeFreeTierEligibleHoursAcrossInstances(
                    freeTierEligibleWindowsInstances,
                    MaxFreeTierEligibleHours);
            }
        }

        private void DistributeFreeTierEligibleHoursAcrossInstances(
            List<MonthlyEc2InstanceUsage> monthlyFreeTierEligibleInstanceUsages,
            int maxFreeTierEligibleHours)
        {
            int remainingFreeTierEligibleHours = maxFreeTierEligibleHours;

            for (int i = 0; i < monthlyFreeTierEligibleInstanceUsages.Count && remainingFreeTierEligibleHours > 0; ++i)
            {
                if (monthlyFreeTierEligibleInstanceUsages[i].BillingType == "OnDemand")
                {
                    var freeTierEligibleInstance = monthlyFreeTierEligibleInstanceUsages[i];
                    var discountedHours = CalculateDiscountedHoursFor(
                        freeTierEligibleInstance,
                        remainingFreeTierEligibleHours
                    );

                    freeTierEligibleInstance.ApplyDiscount(discountedHours);
                    remainingFreeTierEligibleHours -= discountedHours;
                }
                else { monthlyFreeTierEligibleInstanceUsages[i].ApplyDiscount(0); }
            }
        }

        private int CalculateDiscountedHoursFor(
            MonthlyEc2InstanceUsage monthlyFreeTierEligibleInstanceUsage,
            int availableFreeTierEligibleHours)
        {
            var totalBillableHours = monthlyFreeTierEligibleInstanceUsage.GetTotalBillableHours();
            return totalBillableHours < availableFreeTierEligibleHours
                ? totalBillableHours
                : availableFreeTierEligibleHours;
        }
    }
}