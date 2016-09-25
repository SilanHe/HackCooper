using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class FirstTimeLoginPage : ContentPage
	{
		public FirstTimeLoginPage()
		{
			BindingContext = new FirstTimeLoginViewModel(this);
			InitializeComponent();
		}
	}
}
