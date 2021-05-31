using LocatioTracker.MobileApp.Models;
using LocatioTracker.MobileApp.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocatioTracker.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var clinics = new List<Clinic>();
            var clinicButtons = new List<Button>();


            var dummyClinicOne = new Clinic
            {
                ClinicId = 1,
                ClinicName = "Clinic 1",
                City = "Austin"
            };
            var dummyClinicTwo = new Clinic
            {
                ClinicId = 2,
                ClinicName = "Clinic 2",
                City = "Austin"
            };
            var dummyClinicThree = new Clinic
            {
                ClinicId = 11,
                ClinicName = "Clinic 11",
                City = "San Antonio"
            };
            clinics.Add(dummyClinicOne);
            clinics.Add(dummyClinicTwo);
            clinics.Add(dummyClinicThree);

            Application.Current.Properties["Clinics"] = clinics;
            Application.Current.Properties["ClinicButtons"] = clinicButtons;
        }

        private async void AdminClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationsScreen(new Models.Person 
            {
                Role="admin",
                Location=""
            },new MessagingCenter()));
        }

        private async void DoctorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocationsScreen(new Models.Person
            {
                Role = "doctor",
                Location = ""
            }, new MessagingCenter()));
        }
    }
}
