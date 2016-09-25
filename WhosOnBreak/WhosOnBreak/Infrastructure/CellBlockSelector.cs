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
			var timeCell = item as TimeCellModel;

			if (timeCell == null)
				return null;
			else if (timeCell.IsBreak)
				return this.breakDataTemplate;
			else if (timeCell.IsCommon)
				return this.breakDataTemplate;
			else
				return this.busyDataTemplate;
		}
		private readonly DataTemplate breakDataTemplate;
		private readonly DataTemplate commonDataTemplate;
		private readonly DataTemplate busyDataTemplate;
	}

}
