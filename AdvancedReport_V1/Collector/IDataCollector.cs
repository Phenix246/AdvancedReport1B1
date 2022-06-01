using ManageTools.Data;
using ManageTools.Store;


namespace ManageTools.Collector
{
    interface IDataCollector
    {
        void collectData(SDateTime month);

        public IStore<T> getStore<T>() where T : MonthData
        {
            return StoreManager.Instance.get<T>();
        }

    }
}
