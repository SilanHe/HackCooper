using System;
using System.Threading.Tasks;
namespace WhosOnBreak
{
	public class FriendsScheduleHelper
	{

		public static UserModelJson friend = new UserModelJson();

		public static UserModelJson Friend
		{
			get { return friend; }
			set { friend = value; }
		}

		public static async Task GetFriend(string id)
		{
			Friend = await App.dataManager.GetUserAsync(id);
		}

		public static void ClearFriend()
		{
			Friend = new UserModelJson();
		}
	}
}
