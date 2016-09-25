using System;
using System.Collections.ObjectModel;
namespace WhosOnBreak
{
	public class NotificationsPageModel
	{
		public ObservableCollection<NotifModelJson> Notifs { get; set; }
		public NotificationsPageModel()
		{
		}
	}
}
