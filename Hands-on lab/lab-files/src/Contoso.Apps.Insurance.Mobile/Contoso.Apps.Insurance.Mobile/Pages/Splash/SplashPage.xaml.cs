using System.Threading.Tasks;
using CIMobile.Pages.Base;
using CIMobile.ViewModels.Splash;

namespace CIMobile.Pages.Splash
{
	public partial class SplashPage : SplashPageXaml
    {
        public SplashPage()
        {
            InitializeComponent();

            BindingContext = new SplashViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // fetch the demo credentials
            await ViewModel.LoadDemoCredentials();

            // pause for a moment before animations
            await Task.Delay(App.AnimationSpeed);

            // Sequentially animate the login buttons. ScaleTo() makes them "grow" from a singularity to the full button size.
            //await SignInButton.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
            //await SkipSignInButton.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
        }
    }

    /// <summary>
    /// This class definition just gives us a way to reference ModelBoundContentPage<T> in the XAML of this Page.
    /// </summary>
    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    {
    }
}
