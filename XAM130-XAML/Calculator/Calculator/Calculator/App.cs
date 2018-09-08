using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// Turn on the XAML compiler XAMLC to compile the XAML pages
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Calculator
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new MainPageForm();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
