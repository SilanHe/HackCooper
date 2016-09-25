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
<<<<<<< HEAD
			//Title = "";//user name or your schedule
=======
			Title = App.UserRepo.GetUser().Name;//user name or your schedule
>>>>>>> 5094106e4d6434eea135c8cd4cf39458f407a821

		}
	}
}
