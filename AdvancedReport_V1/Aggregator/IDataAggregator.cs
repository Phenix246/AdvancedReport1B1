using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;


namespace AdvancedReport_V1.Aggregator
{
    interface IDataAggregator
    {
        void aggregateData(SDateTime month, SDateTime lastMonth);

        public IStore<K, T> getStore<K, T>() where T : MonthData
        {
            return StoreManager.Instance.get<K, T>();
        }
    }
}
