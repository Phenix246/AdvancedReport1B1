using AdvancedReport_V1.Store;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedReport_V1
{
    public class Main : ModMeta
    {
        public override string Name => Helpers.AdvancedReportName;
        public static bool IsActive { get; set; } = true;

        // Asd

        public override void Initialize(ModController.DLLMod parentMod)
        {
            base.Initialize(parentMod);
            Logger.Log("Main:Initialize : Hello world", false);
        }

        public override void ConstructOptionsScreen(RectTransform parent, bool inGame)
        {
            Text label = WindowManager.SpawnLabel();
            label.text = "Advanced reports";

            WindowManager.AddElementToElement(label.gameObject, parent.gameObject, new Rect(0, 0, 400, 128),
                    new Rect(0, 0, 0, 0));
        }

        public override WriteDictionary Serialize(GameReader.LoadMode mode)
        {
            Logger.Log("Main:Serialize : Start", false);
            var data = new WriteDictionary();

            data["Store"] = StoreManager.Instance.Serialize(mode);

            Logger.Log("Main:Serialize : End", false);
            return data;
        }

        public override void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
        {
            Logger.Log("Main:Deserialize : Start", false);
            StoreManager.Instance.Deserialize(data.Get("Store", new WriteDictionary()), mode);
            Logger.Log("Main:Deserialize : End", false);
        }
    }
}
