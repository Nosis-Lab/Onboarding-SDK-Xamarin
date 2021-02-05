using Nosis.Onboarding.SdkForms;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleSdk.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultDetailPage : ContentPage
	{
		public ResultDetailPage ()
		{
			InitializeComponent();

            ShowDetails();
		}

        private void ShowDetails()
        {
            var sb = new StringBuilder();

            labelNovedadResult.Text = Onboarding.Current.Status;
            labelEntered.Text = Onboarding.Current.DniNum;

            sb.AppendLine($"Es válido: {Onboarding.Current.Dni?.Photo?.IsValid}");
            sb.AppendLine($"Coincidencia: {Onboarding.Current.Dni?.Photo?.Confidence}");
            sb.AppendLine($"Lado: {Onboarding.Current.Dni?.Photo?.Side}");
            labelResultPhotoDetail.Text = sb.ToString();

            if (Onboarding.Current.Dni != null)
            {
                sb.Clear();
                sb.AppendLine($"Es válido: {Onboarding.Current.Dni.Barcode?.IsValid}");
                sb.AppendLine($"Lado: {Onboarding.Current.Dni.Barcode?.Side}");
                sb.AppendLine($"Valor: {Onboarding.Current.Dni.Barcode?.Value}");
                sb.AppendLine($"Numero: {Onboarding.Current.Dni.Barcode?.Number}");
                sb.AppendLine($"Nombre: {Onboarding.Current.Dni.Barcode?.FirstName}");
                sb.AppendLine($"Apellido: {Onboarding.Current.Dni.Barcode?.LastName}");
                sb.AppendLine($"Sexo: {Onboarding.Current.Dni.Barcode?.Gender}");
                sb.AppendLine($"Fecha Nacimiento: {Onboarding.Current.Dni.Barcode?.BirthDate}");
                sb.AppendLine($"Fecha Emisión: {Onboarding.Current.Dni.Barcode?.CreationDate}");
                sb.AppendLine($"Ejemplar: {Onboarding.Current.Dni.Barcode?.Copy}");
                sb.AppendLine($"Número Trámite: {Onboarding.Current.Dni.Barcode?.Order}");
                sb.AppendLine($"Cuit: {Onboarding.Current.Dni.Barcode?.Cuit}");
                labelResultBarcodeDetail.Text = sb.ToString();

                sb.Clear();
                sb.AppendLine($"Es válido: {Onboarding.Current.Dni.Mrz?.IsValid}");
                sb.AppendLine($"Lado: {Onboarding.Current.Dni.Mrz?.Side}");
                sb.AppendLine($"Valor: {Onboarding.Current.Dni.Mrz?.Value}");
                sb.AppendLine($"ID: {Onboarding.Current.Dni.Mrz?.ID}");
                sb.AppendLine($"Número: {Onboarding.Current.Dni.Mrz?.Number}");
                sb.AppendLine($"DV1: {Onboarding.Current.Dni.Mrz?.CD1}");
                sb.AppendLine($"Fecha Nacimiento: {Onboarding.Current.Dni.Mrz?.BirthDate}");
                sb.AppendLine($"DV2: {Onboarding.Current.Dni.Mrz?.CD2}");
                sb.AppendLine($"Sexo: {Onboarding.Current.Dni.Mrz?.Gender}");
                sb.AppendLine($"Fecha Vencimiento: {Onboarding.Current.Dni.Mrz?.ExpirationDate}");
                sb.AppendLine($"DV3: {Onboarding.Current.Dni.Mrz?.CD3}");
                sb.AppendLine($"Nacionalidad: {Onboarding.Current.Dni.Mrz?.Nationality}");
                sb.AppendLine($"DV4: {Onboarding.Current.Dni.Mrz?.CD4}");
                sb.AppendLine($"Nombre: {Onboarding.Current.Dni.Mrz?.FirstName}");
                sb.AppendLine($"Apellido: {Onboarding.Current.Dni.Mrz?.LastName}");
                labelResultMrzDetail.Text = sb.ToString();
            }

            if (Onboarding.Current.Selfie != null)
            {
                sb.Clear();
                sb.AppendLine($"Coincidencia: {Onboarding.Current.Selfie.Confidence}");
                sb.AppendLine($"Origen: {Onboarding.Current.Selfie.Origin}");
                labelResultDetailSelfie.Text = sb.ToString();
            }
        }
    }
}
