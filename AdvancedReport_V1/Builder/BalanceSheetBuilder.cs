using AdvancedReport_V1.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Builder
{
    public class BalanceSheetBuilder
    {
        public static BalanceSheet createBalanceSheet(SDateTime month, Company company)
        {
            var cash = company.Money; // ok
            var plot = 0f;
            var bonds = getBonds(); // ok
            var parts = 0f; // ok
            var subsidiaries = 0f; // ok
            var debts = 0f; // ok


            // GameSettings.Instance.Investments == investment part ??

            foreach (var loan in GameSettings.Instance.Loans)
            {
                debts += loan.Value;
            }

            foreach (Stock stock in company.Stocks)
            {
                parts += stock.CurrentWorth;
            }

            foreach(var investment in GameSettings.Instance.Investments)
            {
                parts += investment.CurrentValue;
            }

            foreach (var sub in company.GetSubsidiaries())
            {
                subsidiaries += sub.Valuation;
            }
            computeEquity(month, company, out float shareCapital, out float retainedEarnings);

            return new BalanceSheet(month, cash, plot, bonds, parts, subsidiaries, debts, shareCapital, retainedEarnings);
        }

        private static void computeEquity(SDateTime month, Company company, out float shareCapital, out float retainedEarnings)
        {
             BalanceSheet lastBalanceSheet = getLastBalanceSheet(month, company);
 
            var ShareSells = Math.Min(0, GameSettings.Instance.BillsCurrent[Company.TransactionCategory.Stocks].GetOrDefault("Miscellaneous", 0));
            

            shareCapital = lastBalanceSheet.ShareCapital + ShareSells;
            retainedEarnings = lastBalanceSheet.RetainedEarnings + computeNetProfit(company.Cashflow);
        }

        private static BalanceSheet getLastBalanceSheet(SDateTime month, Company company)
        {
            // get or with 0 values
            month.
            return null;
        }

        private static SDateTime getPreviousMonth(SDateTime month)
        {
            var newMonth = month.Month - 1;
            var newYear = month.Year;
            if(newMonth == 0)
            {
                newMonth = 12;
                newYear -= 1;
            }
            return new SDateTime(newMonth, newYear);
        }

        private static float computeNetProfit(Dictionary<string, List<float>> cashflow)
        {
            float profit = 0;

            foreach(var category in cashflow)
            {
                foreach(var line in category.Value)
                {
                    profit += line;
                }
            }

            return profit;
        }

        private static float getBonds()
        {
            InsuranceAccount insAcc = GameSettings.Instance.Insurance;
            return insAcc.Money;
        }
    }
}
