using System;
using System.Collections.ObjectModel;
namespace WhosOnBreak
{
	public class NotificationsPageViewModel:MainViewModel
	{
		public NotificationsPageModel notificationsPageModel;
		public NotificationsPageViewModel()
		{
			notificationsPageModel = new NotificationsPageModel();
			Notifs = new ObservableCollection<NotifModelJson>(ApiNotifsHelper.ListOfNotifs);
		}

		public ObservableCollection<NotifModelJson> Notifs
		{
			get { return notificationsPageModel.Notifs;}
			set { notificationsPageModel.Notifs = value; RaisePropertyChanged();}
		}
	}
}
