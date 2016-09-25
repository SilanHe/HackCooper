using System;
using Xamarin.Forms;
namespace WhosOnBreak
{
	public class TimeCellModel
	{
		public TimeCellModel()
		{
		}

		public double Time { get; set; }

		public bool IsBreak { get; set; }

		public bool IsCommon { get; set; }

		//public int IsWhat { get; set; }
		//1:isBreak=true
		//2:isCommon is also True
		//default everything else
	}
}
