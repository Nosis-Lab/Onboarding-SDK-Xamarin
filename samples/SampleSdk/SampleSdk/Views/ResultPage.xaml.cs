using System;
using System.IO;
using Nosis.Onboarding.SdkForms;
using SampleSdk.Utils;
using Xamarin.Forms;

namespace SampleSdk.Views
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var status = Onboarding.Current?.Status ?? string.Empty;
            if (status == "OK")
            {
                imageFondo.Source = "fondo_verde.png";
                labelStatus.Text = "IDENTIDAD VALIDADA";
            }
            else
            {
                imageFondo.Source = "fondo_gris.png";
                labelStatus.Text = status.ToLower();
            }

            if (!string.IsNullOrWhiteSpace(Onboarding.Current?.Selfie?.AvatarPicture))
            {
                var bytes = Convert.FromBase64String(Onboarding.Current.Selfie.AvatarPicture);
                imageAvatar.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
            else
            {
                imageAvatar.Source = "img_avatar.png";
            }

            if (Onboarding.Current?.Dni?.Barcode != null)
            {
                var barcode = Onboarding.Current.Dni.Barcode;
                labelNombre.Text = barcode.FirstName + " " + barcode.LastName;
                labelDni.Text = "DNI " + barcode.Number.FormatearDni();
                labelVencimiento.Text = "Otorgado el " + barcode.CreationDate;
                labelTramite.Text = "Número de trámite " + barcode.Order;
            }
            else
            {
                labelNombre.Text = "";
                labelDni.Text = "";
                labelVencimiento.Text = "";
                labelTramite.Text = "";
            }
        }

        private async void ViewImages_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nosis.Onboarding.SdkForms.Pages.VisorPage());
        }

        private async void ViewDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultDetailPage());
        }
    }
}
