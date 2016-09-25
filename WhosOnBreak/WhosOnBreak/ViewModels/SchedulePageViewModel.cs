using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;

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

		public void FillDay(ObservableCollection<TimeCellViewModel> daySched, List<double> dayList, List<double>FriendList)
		{

			//algorithm to populate the list of timecellviewmodels which are used in the schedule page
			//UserModelJson test = await App.dataManager.GetUserAsync(App.UserRepo.GetUser().ApiId + "");

			for (double i = 0; i / 2 < 24; i++)
			{
				//Debug.WriteLine(FriendList.Contains(i / 2) + " " + dayList.Contains(i / 2));
				if (FriendList.Contains(i/2) && dayList.Contains(i / 2))
				{
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{
						Time = (i / 2),
						IsBreak = true,
						IsCommon = true
					});
				}else if (dayList.Contains(i/2))
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{
						Time = (i / 2),
						IsBreak = true,
						IsCommon = false
						
						
					});

				else
					daySched.Add(new TimeCellViewModel(new TimeCellModel())
					{
						Time = (i / 2),
						IsBreak = false,
						IsCommon = false
						

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
			List<double> friendS=new List<double>();
			switch (dayOfWeek)
			{
				case (1):

					if (FriendsScheduleHelper.Friend.Mon != null){
						
						friendS = FriendsScheduleHelper.Friend.Mon;
						friendS.Add(25);
					}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Mon, friendS);
					break;
				case (2):

					if (FriendsScheduleHelper.Friend.Tue != null)
					{
						friendS = FriendsScheduleHelper.Friend.Tue;
						friendS.Add(25);
					}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Tue, friendS);
					break;
				case (3):

					if (FriendsScheduleHelper.Friend.Wed != null)
					{
						friendS = FriendsScheduleHelper.Friend.Wed;
						friendS.Add(25);}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Wed, friendS);
					break;
				case (4):

					if (FriendsScheduleHelper.Friend.Thu != null)
					{
						friendS = FriendsScheduleHelper.Friend.Thu;
						friendS.Add(25);}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Thu, friendS);
					break;
				case (5):

					if (FriendsScheduleHelper.Friend.Fri != null)
					{
						friendS = FriendsScheduleHelper.Friend.Fri;
						friendS.Add(25);}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Fri, friendS);
					break;
				case (6):

					if (FriendsScheduleHelper.Friend.Sat != null)
					{
						friendS = FriendsScheduleHelper.Friend.Sat;
						friendS.Add(25);}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Sat, friendS);
					break;
				case (7):

					if (FriendsScheduleHelper.Friend.Sund != null)
					{
						friendS = FriendsScheduleHelper.Friend.Sund;
						friendS.Add(25);}
					else
						friendS.Add(25);
					FillDay(OneDay, schedulePageModel.Sun, friendS);
					break;
			}
		}
		public void OnSave()
		{
			ModifyDay(DayOfWeek);
			switch (DayOfWeek)
			{
				case (1):
					App.dataManager.SaveUserAsync(new UserModelJson { Mon = schedulePageModel.Mon, 
						Tue = PersonalScheduleHelper.Myself.Tue,
						Wed = PersonalScheduleHelper.Myself.Wed,
						Thu = PersonalScheduleHelper.Myself.Thu,
						Fri = PersonalScheduleHelper.Myself.Fri,
						Sat = PersonalScheduleHelper.Myself.Sat,
						Sund = PersonalScheduleHelper.Myself.Sund});
					PersonalScheduleHelper.GetMyself();
					break;
				case (2):
					App.dataManager.SaveUserAsync(new UserModelJson { Tue = schedulePageModel.Tue,
						Mon = PersonalScheduleHelper.Myself.Mon,
						Wed = PersonalScheduleHelper.Myself.Wed,
						Thu = PersonalScheduleHelper.Myself.Thu,
						Fri = PersonalScheduleHelper.Myself.Fri,
						Sat = PersonalScheduleHelper.Myself.Sat,
						Sund = PersonalScheduleHelper.Myself.Sund});
					PersonalScheduleHelper.GetMyself();
					break;
				case (3):
					App.dataManager.SaveUserAsync(new UserModelJson { Wed = schedulePageModel.Wed,
						Mon = PersonalScheduleHelper.Myself.Mon,
						Tue = PersonalScheduleHelper.Myself.Tue,
						Thu = PersonalScheduleHelper.Myself.Thu,
						Fri = PersonalScheduleHelper.Myself.Fri,
						Sat = PersonalScheduleHelper.Myself.Sat,
						Sund = PersonalScheduleHelper.Myself.Sund});
					PersonalScheduleHelper.GetMyself();
					break;
				case (4):
					App.dataManager.SaveUserAsync(new UserModelJson { Thu = schedulePageModel.Thu,
						Mon = PersonalScheduleHelper.Myself.Mon,
						Tue = PersonalScheduleHelper.Myself.Tue,
						Wed = PersonalScheduleHelper.Myself.Wed,
						Fri = PersonalScheduleHelper.Myself.Fri,
						Sat = PersonalScheduleHelper.Myself.Sat,
						Sund = PersonalScheduleHelper.Myself.Sund});
					PersonalScheduleHelper.GetMyself();
					break;
				case (5):
					App.dataManager.SaveUserAsync(new UserModelJson { Fri = schedulePageModel.Fri,
						Tue = PersonalScheduleHelper.Myself.Tue,
						Wed = PersonalScheduleHelper.Myself.Wed,
						Thu = PersonalScheduleHelper.Myself.Thu,
						Mon = PersonalScheduleHelper.Myself.Mon,
						Sat = PersonalScheduleHelper.Myself.Sat,
						Sund = PersonalScheduleHelper.Myself.Sund});
					PersonalScheduleHelper.GetMyself();
					break;
				case (6):
					App.dataManager.SaveUserAsync(new UserModelJson { Sat = schedulePageModel.Sat,
						Tue = PersonalScheduleHelper.Myself.Tue,
						Wed = PersonalScheduleHelper.Myself.Wed,
						Thu = PersonalScheduleHelper.Myself.Thu,
						Fri = PersonalScheduleHelper.Myself.Fri,
						Mon = PersonalScheduleHelper.Myself.Mon,
						Sund = PersonalScheduleHelper.Myself.Sund});
					PersonalScheduleHelper.GetMyself();
					break;
				case (7):
					App.dataManager.SaveUserAsync(new UserModelJson { Sund = schedulePageModel.Sun,
						Tue = PersonalScheduleHelper.Myself.Tue,
						Wed = PersonalScheduleHelper.Myself.Wed,
						Thu = PersonalScheduleHelper.Myself.Thu,
						Fri = PersonalScheduleHelper.Myself.Fri,
						Sat = PersonalScheduleHelper.Myself.Sat,
						Mon = PersonalScheduleHelper.Myself.Mon});
					PersonalScheduleHelper.GetMyself();
					break;
			}
		}

		public void ModifyDay(int dayOfWeek)
		{
			//change the List<>
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
