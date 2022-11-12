using AdvancedReport_V1.Data;
using AdvancedReport_V1.Store;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedReport_V1
{
    public class Main : ModMeta
    {
        public override string Name => Helpers.AdvancedReportName;

        // Asd

        public override void Initialize(ModController.DLLMod parentMod)
        {
            base.Initialize(parentMod);
        }

        public override void ConstructOptionsScreen(RectTransform parent, bool inGame)
        {
            Text label = WindowManager.SpawnLabel();
            label.text = "Please load a game and press 'Manage' button.";

            WindowManager.AddElementToElement(label.gameObject, parent.gameObject, new Rect(0, 0, 400, 128),
                    new Rect(0, 0, 0, 0));
        }

        public override WriteDictionary Serialize(GameReader.LoadMode mode)
        {
            var data = new WriteDictionary();

            data["Store"] = StoreManager.Instance.Serialize(mode);

            return data;
        }

        public override void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            StoreManager.Instance.Deserialize(data.Get("Store", new WriteDictionary()), mode);
            SDateTime yearMonth = new SDateTime(TimeOfDay.Instance.Month, TimeOfDay.Instance.Year);
        }
    }
}
