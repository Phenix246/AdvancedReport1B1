using AdvancedReport_V1.Data;

namespace AdvancedReport_V1.Store
{
    public interface IStore<K, T> where T : MonthData
    {
        K Store(T data);

        T Get(K month);

        T GetOrDefault(K month, T value);

        void Deserialize(WriteDictionary data, GameReader.LoadMode mode);

        WriteDictionary Serialize(GameReader.LoadMode mode);
    }
}