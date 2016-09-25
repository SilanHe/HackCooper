using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace WhosOnBreak
{
	public class FirstTimeLoginViewModel:MainViewModel
	{
		FirstTimeLoginModel firstTimeLoginModel;
		public WeakReference weakFirstTimeLoginPage;
		public ICommand OnLogin { get; set; }

		public FirstTimeLoginViewModel(FirstTimeLoginPage firstTimeLoginPage)
		{
			weakFirstTimeLoginPage = new WeakReference(firstTimeLoginPage);
			firstTimeLoginModel = new FirstTimeLoginModel();
			OnLogin = new Command(async () => await Login());
		}

		public FirstTimeLoginPage WeakFirstTimeLoginPage
		{
			get { return weakFirstTimeLoginPage.Target as FirstTimeLoginPage; }
		}

		public string Name
		{
			get { return firstTimeLoginModel.Name; }
			set { firstTimeLoginModel.Name = value; RaisePropertyChanged(); }
		}

		public async Task Login()
		{
			App.UserRepo.AddNewUser(Name);
			/*int id = 0;
			foreach (byte b in System.Text.Encoding.UTF8.GetBytes(Name))
			{
				id += b;
			}
			await App.dataManager.SaveDeuceAsync(new DeuceModelJson() { Id = id, Name = this.Name, AverageLengthOfDeuce = 0, LongestDeuce = 0, NumberOfDeuces = 0, ShortestDeuce = 0 }, true);*/
			await WeakFirstTimeLoginPage.Navigation.PushAsync(new SchedulePage());
		}
	}
}
