using System;
using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;


namespace NetStatus
{
    public class NetworkViewPage : ContentPage
    {
        Label ConnectionDetails = null;

        public NetworkViewPage()
        {
            ConnectionDetails = new Label()
            {
                Text = "Network Connection Available: ",
                TextColor = Color.FromRgb(0x40, 0x40, 0x40),

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                ClassId = "ConnectionDetails"
            };

            this.Content = ConnectionDetails;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConnectionDetails.Text += CrossConnectivity.Current.ConnectionTypes.First().ToString();

            if (CrossConnectivity.Current == null)
            {
                return;
            }

            CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (CrossConnectivity.Current != null)
            {
               //CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
            }
        }

        protected void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current?.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
        }
    }
}

