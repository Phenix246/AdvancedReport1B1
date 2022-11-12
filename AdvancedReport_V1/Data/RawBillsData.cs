﻿using System.Collections.Generic;

namespace AdvancedReport_V1.Data
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
