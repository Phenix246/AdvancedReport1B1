﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1
{
    public static class Helpers
    {
        public static GameSettings Settings => GameSettings.Instance;
        public static bool IsGameLoaded => GameSettings.Instance != null && HUD.Instance != null;
        public static string Version => "0.0.1";
        public static string AdvancedReportName => $"Advanced report v{Version}";
        public static bool IsDebug => false;

        public static List<SimulatedCompany> getSubsidiaries()
        {
            List<SimulatedCompany> subsidiaries = new List<SimulatedCompany>();
            SHashSet<uint> subs = Settings.MyCompany.Subsidiaries;

            foreach (uint sub in subs)
            {
                SimulatedCompany subsidiaryCompany = Settings.simulation.Companies[sub];
                subsidiaries.Add(subsidiaryCompany);
            }

            return subsidiaries;
        }

        public static Company getMyCompany()
        {
            return Settings.MyCompany;
        }

        public static SDateTime getPreviousMonth(SDateTime month)
        {
            var newMonth = month.Month - 1;
            var newYear = month.Year;
            if (newMonth == 0)
            {
                newMonth = 12;
                newYear -= 1;
            }
            return new SDateTime(newMonth, newYear);
        }
    }
}
