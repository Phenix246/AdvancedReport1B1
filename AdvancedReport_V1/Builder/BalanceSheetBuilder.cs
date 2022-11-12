using AdvancedReport_V1.Documents;
using AdvancedReport_V1.Store;
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
            var cash = company.Money;
            var bonds = GameSettings.Instance.Insurance.Money;
            var parts = GameSettings.Instance.Investments.SumSafe((Investment x) => x.CurrentValue) + GameSettings.Instance.MyCompany.NewOwnedStock.Sum((NewStock x) => x.TotalWorth);
            var subsidiaries = GameSettings.Instance.MyCompany.Subsidiaries.SumSafe((uint x) => GameSettings.Instance.simulation.GetCompany(x).GetMoneyWithInsurance(false));
            var loan = GameSettings.Instance.Loans.Sum((KeyValuePair<int, float> x) => (float)x.Key * x.Value);

            var plot = 0f;
            if (!GameSettings.Instance.RentMode)
            {
                plot = GameSettings.Instance.PlayerPlots.SumSafe((PlotArea x) => x.Price - x.Monthly * (float)x.MonthsLeft);
            }

            computeEquity(month, company, out float shareCapital, out float retainedEarnings);

            return new BalanceSheet(month, cash, plot, bonds, parts, subsidiaries, loan, shareCapital, retainedEarnings);
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
            var sMonth = Helpers.getPreviousMonth(month);
            return BalanceSheetStore.Instance.GetOrDefault(sMonth, new BalanceSheet(sMonth, 0,0,0,0,0,0,0,0));
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
    }
}
