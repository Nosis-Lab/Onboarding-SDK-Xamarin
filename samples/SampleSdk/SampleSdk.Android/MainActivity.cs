using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace SampleSdk.Droid
{
    [Activity(
        Label = "Onboarding Sample", 
        Icon = "@drawable/icon", 
        Theme = "@style/SampleTheme.Splash", 
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait,
        ResizeableActivity = false)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(savedInstanceState);

            SetFullscreen();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        private void SetFullscreen()
        {
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            this.Window.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (statusBarHeightInfo == null)
                    statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                statusBarHeightInfo?.SetValue(this, 0);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}