using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhosOnBreak
{
	public class DataManager
	{
		IRestService restService;

		public DataManager(RestService service)
		{
			restService = service;
		}

		public Task<List<NotifModelJson>> GetNotifsAsync(string ownId)
		{
			return restService.RefreshNotifsAsync(ownId);
		}

		public Task<UserModelJson> GetUserAsync(string id)
		{
			return restService.GetUserAsync(id);
		}

		public Task SaveNotifAsync(NotifModelJson notifItem)
		{
			return restService.SaveNotifAsync(notifItem);
		}

		public Task SaveUserAsync(UserModelJson userItem, bool isNewItem = false)
		{
			return restService.SaveUserAsync(userItem, isNewItem);
		}

		public Task DeleteNotifAsync(string id)
		{
			return restService.DeleteNotifsAsync(id);
		}
	}
}
