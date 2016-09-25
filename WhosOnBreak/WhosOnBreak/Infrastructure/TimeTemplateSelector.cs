using System;
using Xamarin.Forms;


namespace WhosOnBreak
{
	public class TimeTemplateSelector : Xamarin.Forms.DataTemplateSelector
	{
		public TimeTemplateSelector()
		{
			// Retain instances!
			this.breakDataTemplate = new DataTemplate(typeof(TimeViewCell));
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var timeCell = item as TimeCellViewModel;

			if (timeCell == null)
				return null;
			
			return this.breakDataTemplate;
			
		}
		private readonly DataTemplate breakDataTemplate;

	}

}
