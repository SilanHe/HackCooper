using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace WhosOnBreak
{
	public class SchedulePageViewModel:MainViewModel 
	{
		public WeakReference weakSchedulePage;
		SchedulePageModel schedulePageModel;
		public ICommand BackButtonClicked { get; set; }
		public ICommand NextButtonClicked { get; set; }
		public ICommand SaveButtonClicked { get; set; }
		int id = App.UserRepo.GetUser().ApiId;
		            
		public SchedulePageViewModel(SchedulePage schedulePage)
		{
			//weakreference
			weakSchedulePage = new WeakReference(schedulePage);
			schedulePageModel = new SchedulePageModel();
			OneDay = new ObservableCollection<TimeCellViewModel>();

			BackButtonClicked = new Command(OnPreviousDay);
			NextButtonClicked = new Command(OnNextDay);
			SaveButtonClicked = new Command(OnSave);

			//default on monday
			DayOfWeek = 1;
			FillDayN(DayOfWeek);
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
		public int DayOfWeek
		{
			get { return schedulePageModel.DayOfWeek; }
			set { schedulePageModel.DayOfWeek = value; RaisePropertyChanged();}
		}

		public ObservableCollection<TimeCellViewModel> OneDay
		{
			get{return schedulePageModel.OneDay;}
			set { schedulePageModel.OneDay = value; RaisePropertyChanged();}
		}

		public void FillDay(ObservableCollection<TimeCellViewModel> daySched, List<double> dayList)
		{

			//algorithm to populate the list of timecellviewmodels which are used in the schedule page

			for (double i = 0; i / 2 < 24; i++)
			{

				if (dayList.Contains(i / 2))
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{

						IsBreak = true,
						IsCommon = false,
						Time = i/2
						
					});

				else
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{
						IsBreak = false,
						IsCommon = false,
						Time = i/2

					});
			}
		}
		public void OnPreviousDay()
		{
			if (DayOfWeek > 1)
				DayOfWeek -= 1;
			else
				DayOfWeek = 7;
			FillDayN(DayOfWeek);

		}

		public void OnNextDay()
		{
			if (DayOfWeek < 7)
				DayOfWeek += 1;
			else
				DayOfWeek = 1;
			FillDayN(DayOfWeek);
		}

		public void FillDayN(int dayOfWeek)
		{
			OneDay.Clear();
			switch (dayOfWeek)
			{
				case (1):
					FillDay(OneDay, schedulePageModel.Mon);
					break;
				case (2):
					FillDay(OneDay, schedulePageModel.Tue);
					break;
				case (3):
					FillDay(OneDay, schedulePageModel.Wed);
					break;
				case (4):
					FillDay(OneDay, schedulePageModel.Thu);
					break;
				case (5):
					FillDay(OneDay, schedulePageModel.Fri);
					break;
				case (6):
					FillDay(OneDay, schedulePageModel.Sat);
					break;
				case (7):
					FillDay(OneDay, schedulePageModel.Sun);
					break;
			}
		}
		public void OnSave()
		{
			ModifyDay(DayOfWeek);
			switch (DayOfWeek)
			{
				case (1):
					App.dataManager.SaveUserAsync(new UserModelJson { Mon = schedulePageModel.Mon });
					break;
				/*case (2):
					ModifySchedule(OneDay, schedulePageModel.Tue);
					break;
				case (3):
					ModifySchedule(OneDay, schedulePageModel.Wed);
					break;
				case (4):
					ModifySchedule(OneDay, schedulePageModel.Thu);
					break;
				case (5):
					ModifySchedule(OneDay, schedulePageModel.Fri);
					break;
				case (6):
					ModifySchedule(OneDay, schedulePageModel.Sat);
					break;
				case (7):
					ModifySchedule(OneDay, schedulePageModel.Sun);
					break;*/
			}
		}

		public void ModifyDay(int dayOfWeek)
		{
			switch (dayOfWeek)
			{
				case (1):
					ModifySchedule(OneDay, schedulePageModel.Mon);
					break;
				case (2):
					ModifySchedule(OneDay, schedulePageModel.Tue);
					break;
				case (3):
					ModifySchedule(OneDay, schedulePageModel.Wed);
					break;
				case (4):
					ModifySchedule(OneDay, schedulePageModel.Thu);
					break;
				case (5):
					ModifySchedule(OneDay, schedulePageModel.Fri);
					break;
				case (6):
					ModifySchedule(OneDay, schedulePageModel.Sat);
					break;
				case (7):
					ModifySchedule(OneDay, schedulePageModel.Sun);
					break;
			}
		}


		public void ModifySchedule(ObservableCollection<TimeCellViewModel> daySched,List<double> dayList)
		{
			foreach(TimeCellViewModel timeCell in daySched)
			{
				if (timeCell.IsBreak)
				{
					dayList.Add(timeCell.Time);

				}
				else if (!timeCell.IsBreak)
				{
					dayList.Remove(timeCell.Time);

				}
			}
		}

	}
}
