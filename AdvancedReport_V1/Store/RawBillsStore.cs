using ManageTools.Data;
using System.Collections.Generic;
using Bills = System.Collections.Generic.Dictionary<Company.TransactionCategory, System.Collections.Generic.Dictionary<string, float>>;
using Key = SDateTime;

namespace ManageTools.Store
{
    class RawBillsStore : IStore<Key, RawBillsData>
    {
        public static IStore<Key, RawBillsData> Instance = new RawBillsStore();

        Dictionary<Key, Bills> Bills = new Dictionary<Key, Bills>();

        public Key store(RawBillsData bills)
        {
            Bills.Add(bills.Month, bills.Bills);
            return bills.Month;
        }

        public RawBillsData get(Key month)
        {
            var sMonth = month.SimplifyMore();
            Bills bill = Bills.GetOrNull(month.SimplifyMore());
            if (bill == null) return null;
            return new RawBillsData(sMonth, bill);
        }
    }
}
