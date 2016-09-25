using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhosOnBreak
{
	public interface IRestService
	{
		Task<List<NotifModelJson>> RefreshNotifsAsync(string ownId);
		Task<UserModelJson> GetUserAsync(string id);
		Task SaveNotifAsync(NotifModelJson notifItem);
		Task SaveUserAsync(UserModelJson userItem, bool isNewItem);
		Task DeleteNotifsAsync(string id);

	}
}
