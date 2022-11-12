using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Collector
{
    class MonthlyMyCompanyCollector : IDataCollector
    {
        public void collectData(SDateTime month)
        {
            Company myCompany = Helpers.getMyCompany();
            var data = myCompany.Cashflow;
            // Stock + value
            // cashflow
        }
    }
}
