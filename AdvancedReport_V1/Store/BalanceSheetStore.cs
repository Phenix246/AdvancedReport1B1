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
            balanceSheets[balanceSheet.Month] = balanceSheet;
            return balanceSheet.Month;
        }

        public void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            Logger.Log("BalanceSheetStore:Deserialize : Start", false);
            var balanceSheetsData = data.Get("balanceSheets", new WriteDictionary());
            var balanceSheets = new Dictionary<SDateTime, BalanceSheet>();
            foreach (var balanceSheetData in balanceSheetsData)
            {
                var balanceSheet = new BalanceSheet((WriteDictionary)balanceSheetData.Value, mode);
                balanceSheets.Add(balanceSheet.Month, balanceSheet);
            }
            this.balanceSheets = balanceSheets;
            Logger.Log("BalanceSheetStore:Deserialize : Stop", false);
        }

        public WriteDictionary Serialize(GameReader.LoadMode mode)
        {
            Logger.Log("BalanceSheetStore:Serialize : Start", false);
            var savedData = new WriteDictionary();

            var balanceSheetsData = new WriteDictionary();

            foreach(var balanceSheet in balanceSheets)
            {
                var serValue = balanceSheet.Value.Serialize(mode);
                var serKey = balanceSheet.Key.ToString();
                balanceSheetsData[serKey] = serValue;
            }

            savedData["balanceSheets"] = balanceSheetsData;

            Logger.Log("BalanceSheetStore:Serialize : End", false);
            return savedData;
        }
    }
}
