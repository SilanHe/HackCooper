using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public int DayOfWeek { get; set; }
		public ObservableCollection<TimeCellViewModel> OneDay { get; set; }

		public SchedulePageModel()
		{
			//mock data
			Mon = new List<double>();
			Tue = new List<double>();
			Wed = new List<double>();
			Thu = new List<double>();
			Sat = new List<double>();
			Sun = new List<double>();
			Fri = new List<double>();
			//doesnt exist in 24h so its our default value
			if (PersonalScheduleHelper.Myself.Mon != null)
			{
				Mon = PersonalScheduleHelper.Myself.Mon;
			}
			if (PersonalScheduleHelper.Myself.Tue != null)
			{
				Tue = PersonalScheduleHelper.Myself.Tue;
			}
			if (PersonalScheduleHelper.Myself.Wed != null)
			{
				Wed = PersonalScheduleHelper.Myself.Wed;
			}
			if (PersonalScheduleHelper.Myself.Thu != null)
			{
				Thu = PersonalScheduleHelper.Myself.Thu;
			}
			if (PersonalScheduleHelper.Myself.Fri != null)
			{
				Fri = PersonalScheduleHelper.Myself.Fri;
			}
			if (PersonalScheduleHelper.Myself.Sat != null)
			{
				Sat = PersonalScheduleHelper.Myself.Sat;
			}
			if (PersonalScheduleHelper.Myself.Sund != null)
			{
				Sun = PersonalScheduleHelper.Myself.Sund;
			}

			Mon.Add(25);
			Tue.Add(25);
			Wed.Add(25);
			Thu.Add(25);
			Fri.Add(25);
			Sat.Add(25);
			Sun.Add(25);
		}

	}
}
