using CIMobile.Pages;
using Xamarin.Forms;

namespace CIMobile
{
	public partial class App : Application
	{
        static Application app;
        public static Application CurrentApp => app;

        //readonly IAuthenticationService _AuthenticationService;

        public App()
        {
            InitializeComponent();

            app = this;
            //_AuthenticationService = DependencyService.Get<IAuthenticationService>();

            // If the App.IsAuthenticated property is false, modally present the SplashPage.

            GoToRoot();
            //if (!_AuthenticationService.IsAuthenticated)
            //{
            //    MainPage = new SplashPage();
            //}
            //else
            //{
            //    GoToRoot();
            //}

        }

        public static void GoToRoot()
        {
            CurrentApp.MainPage = new RootPage();
        }

        public static int AnimationSpeed = 250;
    }
}
