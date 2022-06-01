using ManageTools.Data;
using System.Collections.Generic;
using Products = ManageTools.Data.RawProductData;

namespace ManageTools.Store
{
    class RawProductStore : IStore<RawProductStore.Key, RawProductData>
    {
        public static IStore<Key, RawProductData> Instance = new RawProductStore();

        Dictionary<Key, RawProductData> Products = new Dictionary<Key, Products>();

        public Key store(RawProductData product)
        {
            Key key = new Key(product.Month, product.ProductId);
            Products.Add(key, product);
            return key;
        }

        public RawProductData get(Key key)
        {
            RawProductData product = Products.GetOrNull(key);
            return product;
        }

        public struct Key
        {
            public Key(SDateTime month, uint productId)
            {
                Month = month.SimplifyMore();
                ProductId = productId;
            }

            SDateTime Month { get; }
            uint ProductId { get; }

        }
    }
}
