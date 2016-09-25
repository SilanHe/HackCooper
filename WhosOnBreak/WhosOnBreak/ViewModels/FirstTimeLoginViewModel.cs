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
			int id = 0;
			foreach (byte b in System.Text.Encoding.UTF8.GetBytes(Name))
			{
				id += b;
			}
			App.UserRepo.AddNewUser(Name, id);
			await App.dataManager.SaveUserAsync(new UserModelJson { Name = this.Name, Id = id }, true);
			await WeakFirstTimeLoginPage.Navigation.PushAsync(new MainMasterDetailPage());
		}
	}
}
