using System;
using System.Collections.Generic;


namespace AdvancedReport_V1.Collector
{
    public class DataCollectorManager
    {
        private List<IDataCollector> dataCollectors = new List<IDataCollector>();

        public static readonly DataCollectorManager Instance = new DataCollectorManager();

        private DataCollectorManager()
        {
            init();
        }

        void init()
        {
            dataCollectors.Add(new MyBalanceSheetCollector());
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
