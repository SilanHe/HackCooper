using System;
using Xamarin.Forms;
namespace WhosOnBreak
{
	public class TimeCellViewModel:MainViewModel
	{
		TimeCellModel timeCellModel;
		public TimeCellViewModel(TimeCellModel timeCellModel)
		{
			this.timeCellModel = timeCellModel;
		}

		public double Time
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
		public int IsWhat
		{
			get
			{
				if (IsBreak && IsCommon)//isBreak=true and IsCommon=true
					return 2;
				else if (IsBreak)//isBreak=true but IsCommon=false
					return 1;
				else//IsBreak=false and IsCommon=false
					return 0;
			}
		}


	}
}
