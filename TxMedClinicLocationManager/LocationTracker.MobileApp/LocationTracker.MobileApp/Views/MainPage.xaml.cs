using LocationTracker.Data;
using LocationTracker.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocationTracker.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AdminClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new LocationScreen(new Admin()));
        }
        private async void DoctorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationScreen(new Doctor()));
        }
    }
}
