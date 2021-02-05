using System;
using System.Threading.Tasks;
using Nosis.Onboarding.SdkForms;
using SampleSdk.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleSdk.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
        public StartPage()
		{
			InitializeComponent();

            //NavigationPage.SetHasNavigationBar(this, false);

            entryCuit.Text = Application.Current.Properties.ContainsKey("lastCuit") ? (string)Application.Current.Properties["lastCuit"] : string.Empty;
            entryGrupoOnb.Text = Application.Current.Properties.ContainsKey("grupoOnb") ? (string)Application.Current.Properties["grupoOnb"] : string.Empty;
            lblVersion.Text = string.Format("Versión APP:  v{0}\r\nVersión SDK:  v{1}",
                AppInfo.Version.ToString(),
                Onboarding.Version);
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["lastCuit"] = string.IsNullOrEmpty(entryCuit.Text) ? string.Empty : entryCuit.Text;
            Application.Current.Properties["grupoOnb"] = string.IsNullOrEmpty(entryGrupoOnb.Text) ? string.Empty : entryGrupoOnb.Text;
            await Application.Current.SavePropertiesAsync();

            Onboarding.Settings.GrupoOnb = int.Parse(entryGrupoOnb.Text);
            Onboarding.Settings.FrontDniPageBuilder = () => new UserPage("PASO 1\r\nFRENTE DNI");
            Onboarding.Settings.BackDniPageBuilder = () => new UserPage("PASO 2\r\nDORSO DNI");
            Onboarding.Settings.SelfiePageBuilder = () => new UserPage("PASO 3\r\nSELFIE");

            Onboarding.Settings.OnCompleted = ValidacionCompletada;

            if (await PermissionHelper.CheckAndRequestPermissionAsync(new Permissions.Camera()))
            {
                await Onboarding.Current.StartAsync(entryCuit.Text, null);
            }
        }

        private async Task ValidacionCompletada()
        {
            await Navigation.ReplaceAsync(new ResultPage());
        }
    }
}
