using AdvancedReport_V1.Builder;
using AdvancedReport_V1.Data;
using AdvancedReport_V1.Documents;
using AdvancedReport_V1.Store;
using System;

namespace AdvancedReport_V1.Collector
{
    class MyBalanceSheetCollector : IDataCollector
    {
        public void collectData(SDateTime month)
        {
            var balanceSheet = MyBalanceSheetBuilder.createBalanceSheet(month, Helpers.getMyCompany());
            Logger.Log(balanceSheet);
            StoreManager.Instance.get<SDateTime, BalanceSheet>().Store(balanceSheet);
        }

    }
}
