using System;
using System.Collections.Generic;
using System.Windows;
using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class FriendsPage : ContentPage
	{
		public FriendsPage()
		{
			InitializeComponent();
			BindingContext = new FriendsViewModel(this);
		}

		async void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			FriendModel tappedFriend = (FriendModel)e.Item;
			await FriendsScheduleHelper.GetFriend(tappedFriend.FriendId + "");
			await this.Navigation.PushAsync(new SchedulePage(true));
		}

		protected override async void OnAppearing()
		{
			await SqlFriendsHelper.GetFriendsFromSql();
			base.OnAppearing();
		}
	}
}
