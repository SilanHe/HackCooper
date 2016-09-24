using System;
using System.Collections.Generic;
namespace WhosOnBreak
{
	public class SchedulePageModel
	{
		public string Name { get; set; }

		public List<float> Mon { get; set; }
		public List<float> Tue { get; set; }
		public List<float> Wed { get; set; }
		public List<float> Thu { get; set; }
		public List<float> Fri { get; set; }
		public List<float> Sat { get; set; }
		public List<float> Sun { get; set; }


		public SchedulePageModel()
		{
		}



	}
}
