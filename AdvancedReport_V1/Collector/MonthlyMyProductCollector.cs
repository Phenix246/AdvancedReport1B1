using System;
using AdvancedReport_V1.Builder;
using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;

namespace AdvancedReport_V1.Collector
{
    class MonthlyMyProductCollector : IDataCollector
    {
        public void collectData(SDateTime month)
        {
            foreach(var product in Helpers.getMyCompany().Products)
            {
                var productData = RawProductDataBuilder.createRawProductData(month, product);
                StoreManager.Instance.get<RawProductStore.Key, RawProductData>().store(productData);
            }
        }
    }
}
