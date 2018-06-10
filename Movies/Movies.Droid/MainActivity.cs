using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism.Unity;
using Prism;
using Unity;
using Prism.Ioc;

namespace Movies.Droid
{
    [Activity(Label = "Upcoming movies", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ActionBar.SetIcon(null); 
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
