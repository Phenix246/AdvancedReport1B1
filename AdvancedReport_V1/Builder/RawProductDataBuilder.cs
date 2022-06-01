using ManageTools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageTools.Builder
{
    class RawProductDataBuilder
    {
        public static RawProductData createRawProductData(SDateTime month, SoftwareProduct product)
        {
            var oss = product.OSs;
    
            var userbase = product.Userbase;
            var reputation = product.Rep;

            product.GetRefunds();
            product.GetTotalPhysicalSales();
            product.GetFollowers();
            product.GetAwareness();
            var copies = product.PhysicalCopies;
            var deferStock = product.DeferStock;

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
                GetLastMonthUnitSales(product, true),
                GetLastMonthUnitSales(product, false)
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

        private static int GetLastMonthUnitSales(SoftwareProduct product, bool online)
        {
            List<int> sales = product.GetUnitSales(online);
            if (sales.Count <= 0)
            {
                return 0;
            }
            return sales[sales.Count - 1];
        }
    }
}
