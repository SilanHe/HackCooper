using System.Runtime.CompilerServices;
using System.ComponentModel;
namespace WhosOnBreak
{
	public class MainViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:XamarinMessagingApp.MainViewModel"/> class.
		/// The base view model with RaisePropertyChanged.
		/// </summary>
		public MainViewModel()
		{

		}
		protected void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

	}
}

