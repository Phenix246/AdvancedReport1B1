using System;
using AdvancedReport_V1.Collector;
using AdvancedReport_V1.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AdvancedReport_V1
{
    class AdvancedReportBehaviour : ModBehaviour
    {

		private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			Logger.Log("AdvancedReportBehaviour : OnLevelFinishedLoading : Start", false);

			Logger.Log("isActiveAndEnabled : " + isActiveAndEnabled, false);
			if (Main.IsActive)
			{
							Logger.Log("scene.name " + scene.name, false);

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
						UnsubscribeFromEvents();
						removeUI();
						break;
				}
			}
			Logger.Log("AdvancedReportBehaviour : OnLevelFinishedLoading : End", false);
		}

		#region MonthPassed

		private void SubscribeToEvents()
        {
			Logger.Log("Hellow SubscribeToEvents", false);
            TimeOfDay.OnMonthPassed += (obj, args) => OnMonthPassed(obj, args);
        }

        private void UnsubscribeFromEvents()
        {
			Logger.Log("Hellow UnsubscribeFromEvents", false);
            TimeOfDay.OnMonthPassed -= (obj, args) => OnMonthPassed(obj, args);
        }

		private void addUI()
        {
			SpawnButton();
        }

		private void removeUI()
        {
			Logger.Log("Hellow removeUI", false);
			if(ReportingButton != null) {
				Destroy(ReportingButton.gameObject);
			}
        }

        private void OnMonthPassed(object obj, EventArgs args)
        {
			var month = TimeOfDay.Instance.GetDate().SimplifyMore();

			Logger.Log("Hellow OnMonthPassed month : " + month.ToString(), false);

			DataCollectorManager.Instance.onMonthPassed(month);
		}

		#endregion

		#region Overrides

		public override void OnActivate() {
			Logger.Log("Hellow OnActivate", false);
			Main.IsActive = true;
		}

        public override void OnDeactivate() {
			Logger.Log("Hellow OnDeactivate", false);
			Main.IsActive = false;
		}

		private void Start()
        {
			if (!isActiveAndEnabled)
			{
			return;
			}

			SceneManager.sceneLoaded += OnLevelFinishedLoading;
		}
		#endregion

		#region test

		public static Button ReportingButton;

		public static void SpawnButton()
		{
			ReportingButton = UiUtilities.CreateUIButton(() => CompanyDataWindow.Toggle(), "Reporting", "ReportingButton");

			UiUtilities.AddElementToElement(ReportingButton.gameObject, "MainPanel/Holder/FanPanel", new Rect(364, 0, 100, 32));

		}

		#endregion
	}
}
