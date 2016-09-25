using System;
using System.Collections.Generic;
namespace WhosOnBreak
{
	public class SchedulePageViewModel:MainViewModel 
	{
		public WeakReference weakSchedulePage;
		SchedulePageModel schedulePageModel;

		public SchedulePageViewModel(SchedulePage schedulePage)
		{
			//weakreference
			weakSchedulePage = new WeakReference(schedulePage);
			schedulePageModel = new SchedulePageModel();
		}

		public SchedulePage WeakSchedulePage
		{ 
			get
			{
				return weakSchedulePage.Target as SchedulePage;
			}

		}

		public string Name
		{
			get { return schedulePageModel.Name;}
			set { schedulePageModel.Name = value; RaisePropertyChanged();}
				
		}
		private List<TimeCellViewModel> mon;
		public List<TimeCellViewModel> Mon
		{
			//algorithm to populate the list of timecellviewmodels which are used in the schedule page
			get
			{

				for (int i = 0; i / 2 < schedulePageModel.Mon.Capacity; i++)
				{
					if (schedulePageModel.Mon.Contains(i / 2))
					{
						mon.Add(new TimeCellViewModel(new TimeCellModel())
						{
							Time = i / 2,
							IsBreak = true
						});
					}
					else
						mon.Add(new TimeCellViewModel(new TimeCellModel())
						{
							Time = i / 2,
							IsBreak = false
						});
				}
				return mon;

			}
		}

	}
}
