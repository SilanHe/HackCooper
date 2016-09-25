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

		}
	}
}
