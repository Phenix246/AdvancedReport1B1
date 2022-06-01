using System;
using ManageTools.Builder;
using ManageTools.Data;
using ManageTools.Store;

namespace ManageTools.Collector
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
