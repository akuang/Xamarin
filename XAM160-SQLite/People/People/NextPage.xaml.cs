using People.Models;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People
{
    public partial class NextPage : ContentPage
    {
        protected internal NextPage()
        {
            InitializeComponent();
        }

        public async Task OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async Task OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Person> people = await App.PersonRepo.GetAllPeopleAsync();
            peopleList.ItemsSource = people;
        }
    }
}
