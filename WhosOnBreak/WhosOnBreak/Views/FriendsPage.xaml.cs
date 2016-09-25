using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class FriendsPage : ContentPage
	{
		public FriendsPage()
		{
			BindingContext = new FriendsViewModel(this);
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			await SqlFriendsHelper.GetFriendsFromSql();
			base.OnAppearing();
		}
	}
}
