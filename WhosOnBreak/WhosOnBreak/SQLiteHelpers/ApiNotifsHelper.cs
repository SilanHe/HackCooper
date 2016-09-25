using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WhosOnBreak
{
	public static class ApiNotifsHelper
	{
		public static List<NotifModelJson> listOfNotifs = new List<NotifModelJson>();

		public static List<NotifModelJson> ListOfNotifs
		{
			get { return listOfNotifs; }
			set { listOfNotifs = value; }
		}

		public static async Task GetNotifsFromSql()
		{
			ListOfNotifs = await App.dataManager.GetNotifsAsync(App.UserRepo.GetUser().ApiId + "");
		}
	}
}
