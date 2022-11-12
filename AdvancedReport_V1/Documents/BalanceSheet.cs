using AdvancedReport_V1.Data;
using AdvancedReport_V1.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Documents
{
    public class BalanceSheet : MonthData
    {
        // Assets
        public float Cash { get; private set; }
        public float Plot { get; private set; }
        public float Bonds { get; private set; }
        public float Parts { get; private set; }
        public float Subsidiaries { get; private set; }

        // Liabilities
        public float Loan { get; private set; }

        // Equity
        public float ShareCapital { get; private set; }
        public float RetainedEarnings { get; private set; }

        // Total
        public float TotalVaule { get; private set; }

        public BalanceSheet(SDateTime month, float cash, float plot, float bonds, float parts, float subsidiaries, float loan, float shareCapital, float retaindEarnings)
        {
            Month = month;
            Cash = cash;
            Plot = plot;
            Bonds = bonds;
            Parts = parts;
            Subsidiaries = subsidiaries;
            Loan = loan;
            ShareCapital = shareCapital;
            RetainedEarnings = retaindEarnings;
        }

    }
}
