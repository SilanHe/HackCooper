using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			Monday = new ObservableCollection<TimeCellViewModel>();
			FillDay(Monday, schedulePageModel.Mon);
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

		public ObservableCollection<TimeCellViewModel> Monday
		{
			get{return schedulePageModel.Monday;}
			set { schedulePageModel.Monday = value; RaisePropertyChanged();}
		}

		public void FillDay(ObservableCollection<TimeCellViewModel> daySched,List<double> dayList)
		{

			//algorithm to populate the list of timecellviewmodels which are used in the schedule page

			for (int i = 0; i / 2 < 24; i++)
			{
				if (dayList.Contains(i / 2))
				{
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{
						Time = i / 2,
						IsBreak = true,
						IsCommon = false
					});
				}
				else
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{
						Time = i / 2,
						IsBreak = false,
						IsCommon = false
					});
			}
		}

	}
}
