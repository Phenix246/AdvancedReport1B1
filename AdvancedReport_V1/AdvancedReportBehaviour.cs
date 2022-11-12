using System;
using System.Collections.Generic;
using System.Linq;
using AdvancedReport_V1.Aggregator;
using AdvancedReport_V1.Collector;
using OrbCreationExtensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

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
						// Remove button
						/*if (Main.TrainerButton != null)
						{
							Destroy(Main.TrainerButton.gameObject);
							Destroy(Main.SkillChangeButton.gameObject);
						}*/
						UnsubscribeFromEvents();
						break;
					case "MainScene":
						/*Main.CreateUIButtons();*/
						SubscribeToEvents();
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

        private void OnMonthPassed(object obj, EventArgs args)
        {
			var month = TimeOfDay.Instance.GetDate().SimplifyMore();
			DataCollectorManager.Instance.onMonthPassed(month);
			DataAggregatorManager.Instance.onMonthPassed(month);

		}

		#endregion

		#region Overrides

		public override void OnActivate() { /* Mandatory but not needed */ }

        public override void OnDeactivate() { /* Mandatory but not needed */ }

        #endregion
    }
}
