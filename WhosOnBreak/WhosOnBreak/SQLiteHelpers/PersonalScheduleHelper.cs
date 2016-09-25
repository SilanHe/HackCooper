using System;
using System.Threading.Tasks;
namespace WhosOnBreak
{
	public static class PersonalScheduleHelper
	{
		public static UserModelJson myself = new UserModelJson();

		public static UserModelJson Myself
		{
			get { return myself; }
			set { myself = value; }
		}

		public static async Task GetMyself()
		{
			Myself = await App.dataManager.GetUserAsync(App.UserRepo.GetUser().ApiId + "");
		}
	}
}
