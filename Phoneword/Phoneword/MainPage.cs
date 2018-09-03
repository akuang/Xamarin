using System;
using Core;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Entry phoneNumberText = new Entry {
                Text = "1-855-Xamarin"
            };

            Button translateButton = new Button {
                Text = "Translate"
            };

            Label translatedNumber = new Label
            {
                Text = string.Empty
            };

            Button callButton = new Button {
                Text = "Call",
                IsEnabled = true
            };

            StackLayout layout = new StackLayout
            {
                Padding = 20,
                Spacing = 20,
                Children = {
                    new Label {
                        // set the margin top
                        Margin = new Thickness(left:0, top:100, right:0, bottom:0),
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Enter a Phoneword:"
                    }
                }
            };

            layout.Children.Add(phoneNumberText);
            layout.Children.Add(translatedNumber);
            layout.Children.Add(translateButton);
            layout.Children.Add(callButton);

            this.Content = layout;

            translateButton.Clicked += (s, e) => {
                string phoneNum = PhonewordTranslator.ToNumber(phoneNumberText.Text);
                translatedNumber.Text = phoneNum ?? "Invalid phone number!";
            };
        }
    }
}
