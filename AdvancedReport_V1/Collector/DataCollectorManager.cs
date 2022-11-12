using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedReport_V1;

namespace AdvancedReport_V1.Collector
{
    class DataCollectorManager
    {
        private List<IDataCollector> dataCollectors = new List<IDataCollector>();

        public static DataCollectorManager Instance { get; } = new DataCollectorManager();

        private DataCollectorManager()
        {
            init();
        }

        void init()
        {
            dataCollectors.Add(new MonthlyBillCollector());
        }

        public void onMonthPassed(SDateTime month)
        {
            foreach(var collector in dataCollectors)
            {
                collector.collectData(month);
            }
        }

    }
}
