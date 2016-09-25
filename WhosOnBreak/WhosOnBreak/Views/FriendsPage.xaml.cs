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
			ListOfFriends.ItemTapped += (object sender, ItemTappedEventArgs e)=>
			{
				var selectedCell = e.Item as FriendsViewModel;
				//FriendsViewModel selectedCell = (FriendsViewModel)e.Item;
				//UserModelJson test = await App.dataManager.GetUserAsync(App.UserRepo.GetUser().ApiId + "");
				//UserModelJson friend = await App.dataManager.GetUserAsync(e.item.FriendsId);
				// don't do anything if we just de-selected the row
				//placeholderfix
				//if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
		}

		protected override async void OnAppearing()
		{
			await SqlFriendsHelper.GetFriendsFromSql();
			base.OnAppearing();
		}
	}
}
