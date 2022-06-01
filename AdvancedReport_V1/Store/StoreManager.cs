using ManageTools.Data;
using ManageTools.Persistance;
using System;
using System.Collections.Generic;

namespace ManageTools.Store
{
    class StoreManager : ISaveable
    {
        public static StoreManager Instance { get; } = new StoreManager();

        Dictionary<Type, object> stores = new Dictionary<Type, object>();

        private StoreManager()
        {
            init();
        }

        private void init()
        {
            register(RawBillsStore.Instance);
            register(RawProductStore.Instance);
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
            throw new NotImplementedException();
        }

        public void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            throw new NotImplementedException();
        }
    }
}
