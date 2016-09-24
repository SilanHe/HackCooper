using System;
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

	}
}
