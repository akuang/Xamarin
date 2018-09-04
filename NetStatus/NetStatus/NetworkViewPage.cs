using System;

using Xamarin.Forms;

namespace NetStatus
{
    public class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            Content = new Label()
            {
                Text = "Network Connection Available",
                TextColor = Color.FromRgb(0x40, 0x40, 0x40),

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                ClassId = "ConnectionDetails"
            };
        }
    }
}

