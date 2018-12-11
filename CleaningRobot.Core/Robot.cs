using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot.Core
{
	public class Robot
	{
		private CleanOfficeCommand _cleanOfficeCommand { get; set; }

		public Robot(CleanOfficeCommand cleanOfficeCommand)
		{
			_cleanOfficeCommand = cleanOfficeCommand;
		}

		public void CleanOffice()
		{

		}

		public string GetCleanupReport()
		{
			var report = "";

			return report;
		}
	}
}
