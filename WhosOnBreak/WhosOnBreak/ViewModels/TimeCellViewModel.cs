using System;
namespace WhosOnBreak
{
	public class TimeCellViewModel:MainViewModel
	{
		TimeCellModel timeCellModel;
		public TimeCellViewModel(TimeCellModel timeCellModel)
		{
			this.timeCellModel = timeCellModel;
		}
		public string Time
		{
			get { return timeCellModel.Time;}
			set{timeCellModel.Time = value; RaisePropertyChanged(); }
		}
		public bool IsBreak
		{
			get { return timeCellModel.IsBreak;}
			set { timeCellModel.IsBreak = value; RaisePropertyChanged(); }
		}

		public bool IsCommon
		{
			get { return timeCellModel.IsCommon; }
			set { timeCellModel.IsCommon = value; RaisePropertyChanged(); }
		}

		public bool IsBusy
		{
			get { return !(timeCellModel.IsCommon || timeCellModel.IsBreak);}
		}
	}
}
