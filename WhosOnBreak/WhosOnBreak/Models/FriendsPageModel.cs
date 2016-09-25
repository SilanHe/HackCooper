using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace WhosOnBreak
{
	public class FriendsPageModel
	{
		public ObservableCollection<FriendModel> Friends { get; set; }
		public FriendsPageModel()
		{
		}
	}
}
