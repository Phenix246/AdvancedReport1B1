using AdvancedReport_V1.Data;

namespace AdvancedReport_V1.Store
{
    public interface IStore<K, T> where T : MonthData
    {
        public K Store(T data);

        public T Get(K month);

        public T GetOrDefault(K month, T value);
    }
}
