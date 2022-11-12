using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1.Persistance
{
    interface ISaveable
    {
        public WriteDictionary Serialize(GameReader.LoadMode mode);

        public void Deserialize(WriteDictionary data, GameReader.LoadMode mode);
    }
}
