﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class SchedulePage : ContentPage
	{
		public SchedulePage()
		{

			//reu

			InitializeComponent();
			BindingContext = new SchedulePageViewModel(this);
			Title = "";//user name or your schedule

		}
	}
}