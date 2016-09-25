using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhosOnBreak
{
	public class AddFriendViewModel:MainViewModel
	{

		AddFriendModel addFriendModel;
		public WeakReference weakAddFriendPage;
		public ICommand OnAdd { get; set; }

		public AddFriendViewModel(AddFriendPage addFriendPage)
		{
			weakAddFriendPage = new WeakReference(addFriendPage);
			addFriendModel = new AddFriendModel();
			OnAdd = new Command(async () => await Add());
		}

		public AddFriendPage WeakAddFriendPage
		{
			get { return weakAddFriendPage.Target as AddFriendPage; }
		}

		public string Id
		{
			get { return addFriendModel.Id; }
			set { addFriendModel.Id = value; RaisePropertyChanged(); }
		}

		public async Task Add()
		{
			UserModelJson user = await App.dataManager.GetUserAsync(Id);
			System.Diagnostics.Debug.WriteLine(App.dataManager.GetUserAsync(Id));
			await WeakAddFriendPage.DisplayAlert("Adding a friend", "You are adding: " + user.Name, "ok");
			if (user.Name == "" || user.Name == null)
			{
			}
			else {
				await App.FriendsRepo.AddNewFriendAsync(user.Name, (int)user.Id);
			}
			await WeakAddFriendPage.Navigation.PopToRootAsync();
		}
	}
}
