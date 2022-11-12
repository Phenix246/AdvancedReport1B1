using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Data
{

    class RawProductData : MonthData
    {
        public uint CompanyId { get; private set; }
        public string CompanyName { get; private set; }
        public uint ProductId { get; private set; }
        public string ProductName { get; private set; }
        public float Price { get; private set; }
        public uint UnitSum { get; private set; }
        public uint RefundSum { get; private set; }
        public float Loss { get; private set; }
        public float[] LossBreakdown { get; private set; }
        public float IncomeWithLicence { get; private set; }
        public float IncomeWithoutLicence { get; private set; }

        public int UnitSaleOnline { get; private set; }
        public int UnitSaleOffline { get; private set; }

        public int Refunds { get; private set; }
        public int Userbase { get; private set; }
        public uint Followers { get; private set; }
        public float Reputation { get; private set; }
        public float Awareness { get; private set; }

        public List<uint> OSs { get; private set; }

        public RawProductData(SDateTime month, uint companyId, string companyName, uint productId, string productName, float price, uint unitSum, uint refundSum, float loss, float[] lossBreakdown,
            float incomeWithLicence, float incomeWithoutLicence, int unitSaleOnline, int unitSaleOffline, int refunds, int userbase, uint followers, float reputation, float awareness, List<uint> oss)
        {
            Month = month;
            CompanyId = companyId;
            CompanyName = companyName;
            ProductId = productId;
            ProductName = productName;
            Price = price;
            UnitSum = unitSum;
            RefundSum = refundSum;
            Loss = loss;
            LossBreakdown = lossBreakdown;
            IncomeWithLicence = incomeWithLicence;
            IncomeWithoutLicence = incomeWithoutLicence;
            UnitSaleOnline = unitSaleOnline;
            UnitSaleOffline = unitSaleOffline;
            Refunds = refunds;
            Userbase = userbase;
            Followers = followers;
            Reputation = reputation;
            Awareness = awareness;
            OSs = oss;
        }
    }
}
