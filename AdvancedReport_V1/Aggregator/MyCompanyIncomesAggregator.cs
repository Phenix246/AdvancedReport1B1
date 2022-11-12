using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;

namespace AdvancedReport_V1.Aggregator
{
    class MyCompanyIncomesAggregator : IDataAggregator
    {
        public void aggregateData(SDateTime month, SDateTime lastMonth)
        {
            var billStore = StoreManager.Instance.get<SDateTime, RawBillsData>();
            var bills = billStore.get(month).Bills;

            Dictionary<Company.TransactionCategory, Dictionary<string, float>> incomes = new Dictionary<Company.TransactionCategory, Dictionary<string, float>>();

            foreach (var category in bills)
            {
                Dictionary<string, float> income = new Dictionary<string, float>();

                foreach(var value in category.Value) {
                    if(value.Value > 0)
                    {
                        income[value.Key] = value.Value;
                    }
                }

                incomes[category.Key] = income;
            }

            IncomesData data = new IncomesData(month, incomes);
            var incomeStore = StoreManager.Instance.get<SDateTime, IncomesData>();
            incomeStore.store(data);
        }
    }
}
