using System;

using Xamarin.Forms;

namespace NetStatus
{
    public class NoNetworkPage : ContentPage
    {
        public NoNetworkPage()
        {
            Content = new Label()
            {
                Text = "No Network Connection Available",
                TextColor = Color.FromRgb(0x40, 0x40, 0x40),

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            BackgroundColor = Color.FromRgb(0xf0, 0xf0, 0xf0);
        }
    }
}

