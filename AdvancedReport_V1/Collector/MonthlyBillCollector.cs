using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;
using System;

namespace AdvancedReport_V1.Collector
{
    class MonthlyBillCollector : IDataCollector
    {
        public void collectData(SDateTime month)
        {
            var billData = new RawBillsData(month, Helpers.Settings.BillsCurrent);
            StoreManager.Instance.get<SDateTime, RawBillsData>().store(billData);
        }

    }
}
