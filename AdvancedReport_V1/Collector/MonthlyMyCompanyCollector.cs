using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageTools.Collector
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
