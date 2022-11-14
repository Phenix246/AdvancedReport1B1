using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedReport_V1
{
    public static class Logger
	{
		private static void ConsoleLogWithPropertyName(string str) => DevConsole.Console.Log($"Reporting Property {nameof(str)}: {str}");
		private static void ConsoleLog(string str) => DevConsole.Console.Log(str);

		public static void Log(this string str, bool withPropertyName = true)
        {
			if (withPropertyName)
			{
			    ConsoleLogWithPropertyName(str);
			}
			else
			{
			    ConsoleLog(str);
			}
		}

		public static void Log(this bool str) => ConsoleLogWithPropertyName(str.ToString());
		public static void Log(this int str) => ConsoleLogWithPropertyName(str.ToString());
		public static void Log(this object str) => ConsoleLogWithPropertyName(str.ToString());
		public static void LogException(this Exception ex) => DevConsole.Console.Log($"Reporting Exception: {ex.Message}");
	}
}