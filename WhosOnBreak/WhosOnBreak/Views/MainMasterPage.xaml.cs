using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class MainMasterPage : ContentPage
	{
		public ListView ListView
		{
			get { return listView; }
		}

		public MainMasterPage()
		{
			InitializeComponent();
			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Home",
				TargetType = typeof(SchedulePage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Friends",
				TargetType = typeof(FriendsPage)
			});
			listView.ItemsSource = masterPageItems;

		}
	}
}
