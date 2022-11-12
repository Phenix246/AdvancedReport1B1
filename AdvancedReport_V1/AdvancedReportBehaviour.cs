using System;
using AdvancedReport_V1.Collector;
using UnityEngine.SceneManagement;

namespace AdvancedReport_V1
{
    class AdvancedReportBehaviour : ModBehaviour
    {

		private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			if (isActiveAndEnabled)
			{
				switch (scene.name)
				{
					case "MainMenu":
						UnsubscribeFromEvents();
						removeUI();
						break;
					case "MainScene":
						SubscribeToEvents();
						addUI();
						break;
					default:
						goto case "MainMenu";
				}
			}
		}

		#region MonthPassed

		private void SubscribeToEvents()
        {
            TimeOfDay.OnMonthPassed += (obj, args) => OnMonthPassed(obj, args);
        }

        private void UnsubscribeFromEvents()
        {
            TimeOfDay.OnMonthPassed -= (obj, args) => OnMonthPassed(obj, args);
        }

		private void addUI()
        {

        }

		private void removeUI()
        {

        }

        private void OnMonthPassed(object obj, EventArgs args)
        {
			var month = TimeOfDay.Instance.GetDate().SimplifyMore();
			DataCollectorManager.Instance.onMonthPassed(month);
		}

		#endregion

		#region Overrides

		public override void OnActivate() { /* Mandatory but not needed */ }

        public override void OnDeactivate() { /* Mandatory but not needed */ }

        #endregion
    }
}
