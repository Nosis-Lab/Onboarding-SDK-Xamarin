using Nosis.Onboarding.SdkForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SampleSdk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Para usar el sdk de onboarding es necesario obtener una API-KEY de Nosis
            Onboarding.Settings.ApiKey = "my-generated-api-key";

            Current.MainPage = new NavigationPage(new Views.StartPage());
        }
    }
}
