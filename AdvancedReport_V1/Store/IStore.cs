using AdvancedReport_V1.Data;

namespace AdvancedReport_V1.Store
{
    public interface IStore<K, T> where T : MonthData
    {
        public K store(T data);

        public T get(K month);
    }
}
