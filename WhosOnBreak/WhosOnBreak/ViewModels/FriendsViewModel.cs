using System;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhosOnBreak
{
	public class FriendsViewModel:MainViewModel
	{
		FriendsPageModel friendsPageModel;
		public WeakReference weakFriendsPage;
		public ICommand OnAddFriend { get; set; }

		public FriendsViewModel(FriendsPage friendsPage)
		{
			weakFriendsPage = new WeakReference(friendsPage);
			friendsPageModel = new FriendsPageModel();
			Friends = new ObservableCollection<FriendModel>(SqlFriendsHelper.ListOfFriends);
			OnAddFriend = new Command(async () => await AddFriend());
		}

		public FriendsPage WeakFriendsPage
		{
			get { return weakFriendsPage.Target as FriendsPage;}
		}

		public ObservableCollection<FriendModel> Friends
		{
			get { return friendsPageModel.Friends;}
			set { friendsPageModel.Friends = value; RaisePropertyChanged();}
		}

		public async Task AddFriend()
		{
			await WeakFriendsPage.Navigation.PushAsync(new AddFriendPage());
		}
	}
}
