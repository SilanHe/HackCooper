using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class SchedulePage : ContentPage
	{
		public SchedulePage(bool isFriendsSchedule = false)
		{
			InitializeComponent();
			BindingContext = new SchedulePageViewModel(this);
			Title = App.UserRepo.GetUser().Name + App.UserRepo.GetUser().ApiId;//user name or your schedule

			if (!isFriendsSchedule)
			{
				Schedule.ItemTapped += (object sender, ItemTappedEventArgs e) =>
				{
					TimeCellViewModel selectedCell = (TimeCellViewModel)e.Item;
					selectedCell.IsBreak = !selectedCell.IsBreak;
					// don't do anything if we just de-selected the row
					//placeholderfix
					//if (e.Item == null) return;
					// do something with e.SelectedItem
					((ListView)sender).SelectedItem = null; // de-select the row
				};
			}else{
				Schedule.ItemTapped += OnCommonTapped;
			}

		}

		public async void OnCommonTapped(object sender, ItemTappedEventArgs e)
		{
			TimeCellViewModel timeSlot = (TimeCellViewModel)e.Item;
			if (timeSlot.IsCommon)
			{
				var answer = await this.DisplayAlert("Sending invite", "Send notification to hang out?", "Yes", "No");
				if (answer)
				{
					await App.dataManager.SaveNotifAsync(new NotifModelJson
					{
						NotifBy = App.UserRepo.GetUser().Name,
						NotifTo = FriendsScheduleHelper.Friend.Id,
						Time = timeSlot.Time
					});
				}
			}
		}
	}
}
