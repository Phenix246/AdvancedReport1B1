using ManageTools.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageTools.Store
{
    interface IStore<K, T> where T : MonthData
    {
        public K store(T data);

        public T get(K month);
    }
}
