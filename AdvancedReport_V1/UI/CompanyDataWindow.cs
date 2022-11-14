using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AdvancedReport_V1.UI
{
	public class CompanyDataWindow : MonoBehaviour
	{
		public static GUIWindow Window { get; set; }

		private static readonly CompanyDataWindow Instance = new CompanyDataWindow();

		public GUIWorkSheet Worksheet;


		public static bool Shown;

		public GameObject SheetPanel;

		public static void Toggle()
		{
			if (Window == null)
			{
				Instance.Init();
			}
			else
			{
				Window.Toggle();
			}

			Shown = Window.Shown;
		}

		private void Init()
		{
			Window = WindowManager.SpawnWindow();
			Window.InitialTitle = Window.TitleText.text = Window.NonLocTitle = "Reporting";
			Window.name = "Reporting";
			Window.MainPanel.name = "Reporting";

			this.Worksheet.Width = 5;
			this.Worksheet.Height = 11;
			this.Worksheet.Initialize();
			//this.UpdateHeaders();
			/*this.Worksheet.MarkRow(0, Color.white);
			/*this.Worksheet[1, 0].fontStyle = FontStyle.Bold;
			this.Worksheet[2, 0].fontStyle = FontStyle.Bold;
			this.Worksheet[3, 0].fontStyle = FontStyle.Bold;
			this.Worksheet[4, 0].fontStyle = FontStyle.Bold;*/

		}
	}
}
