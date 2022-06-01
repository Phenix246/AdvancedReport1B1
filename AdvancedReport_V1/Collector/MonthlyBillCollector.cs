using ManageTools.Data;
using ManageTools.Store;
using System;

namespace ManageTools.Collector
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
