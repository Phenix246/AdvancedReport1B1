using System.Collections.Generic;

namespace ManageTools.Data
{
    class RawBillsData : MonthData
    {
        public Dictionary<Company.TransactionCategory, Dictionary<string, float>> Bills { get; private set; }

        public RawBillsData(SDateTime month, Dictionary<Company.TransactionCategory, Dictionary<string, float>> bills)
        {
            this.Month = month.SimplifyMore();
            this.Bills = new Dictionary<Company.TransactionCategory, Dictionary<string, float>>(bills);
        }
    }
}
