using System;
using ManageTools.Builder;
using ManageTools.Data;
using ManageTools.Store;

namespace ManageTools.Collector
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
