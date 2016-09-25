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

		public ObservableCollection<TimeCellViewModel> Monday { get; set; }
		public ObservableCollection<TimeCellViewModel> Tuesday { get; set; }
		public ObservableCollection<TimeCellViewModel> Wednesday { get; set; }
		public ObservableCollection<TimeCellViewModel> Thursday { get; set; }
		public ObservableCollection<TimeCellViewModel> Friday { get; set; }
		public ObservableCollection<TimeCellViewModel> Saturday { get; set; }
		public ObservableCollection<TimeCellViewModel> Sunday { get; set; }


		public SchedulePageModel()
		{
			//mock data
			Mon = new List<double>();
			Mon.Add(8);
			Mon.Add(8.5);
			Mon.Add(13);
			Mon.Add(13.5);
		}

	}
}
