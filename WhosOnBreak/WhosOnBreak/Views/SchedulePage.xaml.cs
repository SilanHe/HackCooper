using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class SchedulePage : ContentPage
	{
		public SchedulePage()
		{
			InitializeComponent();
			BindingContext = new SchedulePageViewModel(this);
			Title = App.UserRepo.GetUser().Name;//user name or your schedule
			Schedule.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				
				// don't do anything if we just de-selected the row
				//placeholderfix
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};

		}
	}
}
