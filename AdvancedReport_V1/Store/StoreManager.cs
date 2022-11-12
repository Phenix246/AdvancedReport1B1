using AdvancedReport_V1.Data;
using AdvancedReport_V1.Persistance;
using System;
using System.Collections.Generic;

namespace AdvancedReport_V1.Store
{
    class StoreManager
    {
        public static StoreManager Instance { get; } = new StoreManager();

        Dictionary<Type, object> stores = new Dictionary<Type, object>();

        private StoreManager()
        {
            init();
        }

        private void init()
        {
            register(BalanceSheetStore.Instance);
        }

        private void register<K, T>(IStore<K, T> store) where T : MonthData
        {
            stores.Add(typeof(T), store);

        }

        public IStore<K, T> get<K, T>() where T : MonthData
        {
            return (IStore<K, T> )stores.GetOrNull(typeof(T));
        }

        public WriteDictionary Serialize(GameReader.LoadMode mode)
        {
            var data = new WriteDictionary();
            data["store"] = stores;
            return data;
        }

        public void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            stores = (Dictionary<Type, object>)data["store"];
        }
    }
}
