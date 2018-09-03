using System;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            StackLayout layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to Xamarin.Forms!"
                    }
                }
            };

            Content = layout;
        }
    }
}
