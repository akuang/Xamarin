using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace People
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            nextPage.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new NextPage());
            };

        }

        public string Text
        {
            get
            {
                return textLabel.Text;
            }
            set
            {
                textLabel.Text = value;
            }
        }
    }
}
