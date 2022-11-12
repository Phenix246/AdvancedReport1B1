using AdvancedReport_V1.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Store
{
    internal class BalanceSheetStore : IStore<SDateTime, BalanceSheet>
    {
        public static IStore<SDateTime, BalanceSheet> Instance = new BalanceSheetStore();

        private Dictionary<SDateTime, BalanceSheet> balanceSheets = new Dictionary<SDateTime, BalanceSheet>();

        public BalanceSheet Get(SDateTime month)
        {
            var sMonth = month.SimplifyMore();
            BalanceSheet balanceSheet = balanceSheets.GetOrNull(sMonth);
            if (balanceSheet == null) return null;
            return balanceSheet;
        }

        public BalanceSheet GetOrDefault(SDateTime month, BalanceSheet value)
        {
            var sMonth = month.SimplifyMore();
            BalanceSheet balanceSheet = balanceSheets.GetOrNull(sMonth);
            if (balanceSheet == null) return value;
            return balanceSheet;
        }

        public SDateTime Store(BalanceSheet balanceSheet)
        {
            balanceSheets.Add(balanceSheet.Month, balanceSheet);
            return balanceSheet.Month;
        }
    }
}
