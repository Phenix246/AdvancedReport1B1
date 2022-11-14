using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;


namespace AdvancedReport_V1.Collector
{
    interface IDataCollector
    {
        void collectData(SDateTime month);
    }
}
