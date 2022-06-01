using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageTools;

namespace ManageTools.Collector
{
    class DataCollectorManager
    {
        private List<IDataCollector> dataCollectors = new List<IDataCollector>();

        public DataCollectorManager Instance { get; } = new DataCollectorManager();

        private DataCollectorManager()
        {
            init();
        }

        void init()
        {
            dataCollectors.Add(new MonthlyBillCollector());
            TimeOfDay.OnMonthPassed += onMonthPassed;
        }

        void onMonthPassed(object? sender, EventArgs e)
        {
            var month = TimeOfDay.Instance.GetDate().SimplifyMore();
            foreach(var collector in dataCollectors)
            {
                collector.collectData(month);
            }
        }

    }
}
