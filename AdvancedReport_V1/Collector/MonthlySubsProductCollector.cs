using System;
using AdvancedReport_V1.Builder;
using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;

namespace AdvancedReport_V1.Collector
{
    class MonthlySubsProductCollector : IDataCollector
    {
        public void collectData(SDateTime month)
        {
            foreach (var sub in Helpers.getSubsidiaries())
            {
                foreach(var product in sub.Products)
                {
                    var productData = RawProductDataBuilder.createRawProductData(month, product);
                    StoreManager.Instance.get<RawProductStore.Key, RawProductData>().store(productData);
                }
            }
        }
    }
}
