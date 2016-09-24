using System;
using Xamarin.Forms;


namespace WhosOnBreak
{
	public class CellBlockSelector : Xamarin.Forms.DataTemplateSelector
	{
		public CellBlockSelector()
		{
			// Retain instances!
			this.breakDataTemplate = new DataTemplate(typeof(BreakViewCell));
			this.commonDataTemplate = new DataTemplate(typeof(CommonViewCell));
			this.busyDataTemplate = new DataTemplate(typeof(BusyViewCell));


		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var timeCell = item as MessageViewModel;
			if (timeCell == null)
				return null;
			return messageVm.IsIncoming ? this.incomingDataTemplate : this.outgoingDataTemplate;
		}

		private readonly DataTemplate breakDataTemplate;
		private readonly DataTemplate commonDataTemplate;
		private readonly DataTemplate busyDataTemplate;
	}

}
