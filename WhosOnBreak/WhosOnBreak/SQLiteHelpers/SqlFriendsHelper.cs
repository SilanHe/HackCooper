using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WhosOnBreak
{
	public static class SqlFriendsHelper
	{
		public static List<FriendModel> listOfFriends = new List<FriendModel>();

		public static List<FriendModel> ListOfFriends
		{
			get { return listOfFriends; }
			set { listOfFriends = value; }
		}

		public static async Task GetFriendsFromSql()
		{
			ListOfFriends = await App.FriendsRepo.GetFriendsAsync();
		}
	}
}
