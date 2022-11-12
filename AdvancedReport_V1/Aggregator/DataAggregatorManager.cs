using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedReport_V1;

namespace AdvancedReport_V1.Aggregator
{
    class DataAggregatorManager
    {
        private List<IDataAggregator> dataAggregators = new List<IDataAggregator>();

        public static DataAggregatorManager Instance { get; } = new DataAggregatorManager();

        private DataAggregatorManager()
        {
            init();
        }

        void init()
        {
            dataAggregators.Add(new MyCompanyIncomesAggregator());
            dataAggregators.Add(new MyCompanyExpensesAggregator());
        }

        public void onMonthPassed(SDateTime month)
        {
            var lastMonth = getPreviousMonth(month);

            foreach (var aggregator in dataAggregators)
            {
                aggregator.aggregateData(month, lastMonth);
            }
        }

        private SDateTime getPreviousMonth(SDateTime month)
        {
            return month - ONE_MONTH;
        }

        static readonly SDateTime ONE_MONTH = new SDateTime(1, 0);
    }
}
