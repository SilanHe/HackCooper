using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class AddFriendPage : ContentPage
	{
		public AddFriendPage()
		{
			BindingContext = new AddFriendViewModel(this);
			InitializeComponent();
		}
	}
}
