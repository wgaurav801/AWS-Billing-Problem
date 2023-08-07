using BillingEngine.Models;
using BillingEngine.Models.Billing;
using static BillingEngine.Models.Ec2.OperatingSystem;

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
                var freeTierEligibleLinuxInstances = monthlyBill.GetFreeTierEligibleInstanceUsagesOfType(Linux);
                var freeTierEligibleWindowsInstances = monthlyBill.GetFreeTierEligibleInstanceUsagesOfType(Windows);

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
                var freeTierEligibleInstance = monthlyFreeTierEligibleInstanceUsages[i];
                var discountedHours = CalculateDiscountedHoursFor(
                    freeTierEligibleInstance,
                    remainingFreeTierEligibleHours
                );

                freeTierEligibleInstance.ApplyDiscount(discountedHours);

                remainingFreeTierEligibleHours -= discountedHours;
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