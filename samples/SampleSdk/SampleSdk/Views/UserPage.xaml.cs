using System;
using Nosis.Onboarding.SdkForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleSdk.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage(string message)
        {
            InitializeComponent();

            lblMessage.Text = message;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Onboarding.Current.NextAsync();
        }
    }
}