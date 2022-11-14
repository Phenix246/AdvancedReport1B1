using AdvancedReport_V1.Data;
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
            Logger.Log("StoreManager:Serialize : Start", false);
            var data = new WriteDictionary();

            var storesSaved = new WriteDictionary();

            storesSaved["BalanceSheetStore"] = BalanceSheetStore.Instance.Serialize(mode);


            data["stores"] = storesSaved;
            Logger.Log("StoreManager:Serialize : End", false);
            return data;
        }

        public void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            Logger.Log("StoreManager:Deserialize : Start", false);
            var storesSaved = data.Get("stores", new WriteDictionary());

            var balanceSheetStoreSaved = storesSaved.Get("BalanceSheetStore", (WriteDictionary)null);
            if(balanceSheetStoreSaved != null) {
                BalanceSheetStore.Instance.Deserialize(balanceSheetStoreSaved, mode);
            } 
            Logger.Log("StoreManager:Deserialize : End", false);           
        }
    }
}
