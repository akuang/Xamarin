using System;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NetStatus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                MainPage = new NetworkViewPage();
            }
            else
            {
                MainPage = new NoNetworkPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            CrossConnectivity.Current.ConnectivityChanged += (s, e) =>
            {
                if (e.IsConnected)
                {
                    this.MainPage = new NetworkViewPage();
                }
                else
                {
                    MainPage = new NoNetworkPage();
                }
            };
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
