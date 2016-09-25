using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class MainMasterDetailPage : MasterDetailPage
	{
		public MainMasterDetailPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
			masterPage.ListView.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}

		protected override async void OnAppearing()
		{
			await ApiNotifsHelper.GetNotifsFromSql();
			await SqlFriendsHelper.GetFriendsFromSql();
			base.OnAppearing();
		}
	}
}
