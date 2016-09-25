using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class NotificationsPage : ContentPage
	{
		public NotificationsPage()
		{
			BindingContext = new NotificationsPageViewModel();
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			for (int i = 0; i < ApiNotifsHelper.ListOfNotifs.Count; i++)
			{
				await App.dataManager.DeleteNotifAsync(ApiNotifsHelper.ListOfNotifs[i].Id);	
			}

			await ApiNotifsHelper.GetNotifsFromSql();
			base.OnAppearing();
		}
	}
}
