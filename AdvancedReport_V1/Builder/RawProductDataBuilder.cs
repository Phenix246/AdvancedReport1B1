using AdvancedReport_V1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Builder
{
    class RawProductDataBuilder
    {
        public static RawProductData createRawProductData(SDateTime month, SoftwareProduct product)
        {   
            RawProductData data = new RawProductData(month,
                product.DevCompany.ID,
                product.DevCompany.Name,
                product.ID,
                product.Name,
                product.Price,
                product.UnitSum,
                product.RefundSum,
                product.Loss,
                product.LossBreakdown,
                getLastMonthIncome(product, true),
                getLastMonthIncome(product, false),
                getLastMonthUnitSales(product, true),
                getLastMonthUnitSales(product, false),
                getLastMonthRefunds(product)
                product.Userbase,
                product.Followers,
                getLastMonthRep(product),
                product.GetAwareness(),
                getOSs(product)
            );
            return data;
        }

        private static float getLastMonthIncome(SoftwareProduct product, bool licence)
        {
            List<float> cashflow = product.GetCashflow(licence);
            if (cashflow.Count <= 0)
            {
                return 0f;
            }
            return cashflow[cashflow.Count - 1];
        }

        private static int getLastMonthUnitSales(SoftwareProduct product, bool online)
        {
            List<int> sales = product.GetUnitSales(online);
            if (sales.Count <= 0)
            {
                return 0;
            }
            return sales[sales.Count - 1];
        }

        private static int getLastMonthRefunds(SoftwareProduct product)
        {
            List<int> refunds = product.GetRefunds();
            if (refunds.Count <= 0)
            {
                return 0;
            }
            return refunds[refunds.Count - 1];
        }

        private static float getLastMonthRep(SoftwareProduct product)
        {
            List<float> rep = product.Rep;
            if (rep.Count <= 0)
            {
                return 0f;
            }
            return rep[rep.Count - 1];
        }

        private static List<uint> getOSs(SoftwareProduct product)
        {
            List<uint> oss = new List<uint>();
            foreach(var os in product.OSs)
            {
                oss.Add(os.ID);
            }
            return oss;
        }
    }
}
