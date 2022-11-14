using AdvancedReport_V1.Data;
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
        public float TotalValue { get; private set; }

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
            TotalValue = Cash + Plot + Bonds + Parts + Subsidiaries;
            Logger.Log(this);
        }

        public BalanceSheet(WriteDictionary data, GameReader.LoadMode mode)
        {
            Deserialize(data, mode);
            TotalValue = Cash + Plot + Bonds + Parts + Subsidiaries;
            Logger.Log(this);
        }

        public override string ToString()
        {
            return $"BalanceSheet[Month='{Month.ToString()}', Cash='{Cash.Currency(true)}', Plot='{Plot.Currency(true)}', Bonds='{Bonds.Currency(true)}', Parts='{Parts.Currency(true)}', Subsidiaries='{Subsidiaries.Currency(true)}', Loan='{Loan.Currency(true)}', ShareCapital='{ShareCapital.Currency(true)}', RetainedEarnings='{RetainedEarnings.Currency(true)}'";
        }

        public override void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            data.Get("Month", 0);
            Month = SDateTime.FromInt(data.Get("Month", 0));
            Cash = data.Get("Cash", 0f);
            Plot = data.Get("Plot", 0f);
            Bonds = data.Get("Bonds", 0f);
            Parts = data.Get("Parts", 0f);
            Subsidiaries = data.Get("Subsidiaries", 0f);
            Loan = data.Get("Loan", 0f);
            ShareCapital = data.Get("ShareCapital", 0f);
            RetainedEarnings = data.Get("RetainedEarnings", 0f);
        }

        public override WriteDictionary Serialize(GameReader.LoadMode mode)
        {
            WriteDictionary savedData = new WriteDictionary();

            savedData["Month"] = Month.ToInt();
            savedData["Cash"] = Cash;
            savedData["Bonds"] = Bonds;
            savedData["Plot"] = Plot;
            savedData["Parts"] = Parts;
            savedData["Subsidiaries"] = Subsidiaries;
            savedData["Loan"] = Loan;
            savedData["ShareCapital"] = ShareCapital;
            savedData["RetainedEarnings"] = RetainedEarnings;

            return savedData;
        }
    }
}
