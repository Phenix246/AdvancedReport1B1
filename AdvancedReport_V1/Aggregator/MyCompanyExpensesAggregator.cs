using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;

namespace AdvancedReport_V1.Aggregator
{
    class MyCompanyExpensesAggregator : IDataAggregator
    {
        public void aggregateData(SDateTime month, SDateTime lastMonth)
        {
            var billStore = StoreManager.Instance.get<SDateTime, RawBillsData>();
            var bills = billStore.get(month).Bills;

            Dictionary<Company.TransactionCategory, Dictionary<string, float>> expenses = new Dictionary<Company.TransactionCategory, Dictionary<string, float>>();

            foreach (var category in bills)
            {
                Dictionary<string, float> expense = new Dictionary<string, float>();

                foreach (var value in category.Value)
                {
                    if (value.Value < 0)
                    {
                        expense[value.Key] = value.Value;
                    }
                }

                expenses[category.Key] = expense;
            }


            ExpensesData data = new ExpensesData(month, expenses);
            var incomeStore = StoreManager.Instance.get<SDateTime, ExpensesData>();
            incomeStore.store(data);
        }
    }
}
