using System;
using System.Collections.Generic;
namespace WhosOnBreak
{
	public class SchedulePageModel
	{
		public string Name { get; set; }

		public List<double> Mon { get; set; }
		public List<double> Tue { get; set; }
		public List<double> Wed { get; set; }
		public List<double> Thu { get; set; }
		public List<double> Fri { get; set; }
		public List<double> Sat { get; set; }
		public List<double> Sun { get; set; }


		public SchedulePageModel()
		{
			//mock data
			Mon.Add(8);
			Mon.Add(8.5);
			Mon.Add(13);
			Mon.Add(13.5);
		}



	}
}
