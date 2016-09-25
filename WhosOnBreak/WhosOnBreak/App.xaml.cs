using Xamarin.Forms;

namespace WhosOnBreak
{
	public partial class App : Application
	{
		//properties
		public static UserRepository UserRepo { get; private set; }
		public static DataManager dataManager { get; private set;}

		public App(string dbPath)
		{
			InitializeComponent();
<<<<<<< HEAD

			MainPage = new NavigationPage(new SchedulePage());
=======
			dataManager = new DataManager(new RestService());
			UserRepo = new UserRepository(dbPath);
			UserRepo.ClearUsers();
			if (UserRepo.GetUser().Name == null)
			{
				MainPage = new NavigationPage(new FirstTimeLoginPage());
			}
			else
			{
				MainPage = new SchedulePage();
			}
>>>>>>> 5094106e4d6434eea135c8cd4cf39458f407a821
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
