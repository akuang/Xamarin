using System;
using System.Linq;
using Plugin.Connectivity;
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
        }
    }
}

