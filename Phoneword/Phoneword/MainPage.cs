using System;
using Core;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        string phoneNum = string.Empty;

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
                IsEnabled = false
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
                phoneNum = PhonewordTranslator.ToNumber(phoneNumberText.Text);

                if (!string.IsNullOrEmpty(phoneNum))
                {
                    translatedNumber.TextColor = Color.Green;
                    translatedNumber.Text = phoneNum;

                    callButton.IsEnabled = true;
                    callButton.Text = $"Call: {phoneNum}";
                }
                else
                {
                    translatedNumber.TextColor = Color.Red;
                    translatedNumber.Text = "Invalid phone number!";

                    callButton.IsEnabled = false;
                    callButton.Text = "Call";
                }
            };

            callButton.Clicked += OnCall;
        }

        async void OnCall(object sender, EventArgs e)
        {
            bool result = await this.DisplayAlert(title: "Dial a Number", 
                                                  message: $"Would you like to call {phoneNum}", 
                                                  accept: "Yes", 
                                                  cancel: "No");
            if (result)
            {
                // TODO: dial the phone
                IDialer dialer = DependencyService.Get<IDialer>();

                if (dialer != null)
                {
                    await dialer.DialAsync(phoneNum);
                }
            }
        }
    }
}
