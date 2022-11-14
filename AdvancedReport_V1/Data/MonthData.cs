
namespace AdvancedReport_V1.Data
{
    public abstract class MonthData
    {
        public SDateTime Month { get; protected set; }

        public abstract void Deserialize(WriteDictionary data, GameReader.LoadMode mode);
        public abstract WriteDictionary Serialize(GameReader.LoadMode mode);
    }
}
