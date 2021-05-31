using LocatioTracker.MobileApp.Models;
using LocatioTracker.MobileApp.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocatioTracker.MobileApp.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClinicScreen : ContentPage
    {
        public string ClinicCity { get; set; }
        public string ClinicName { get; set; }
        private int ClinicId { get; set; }
        public IMessagingCenter MessagingCenter { get; set; }
        public NewClinicScreen(IMessagingCenter messaging)
        {
            BindingContext = this;
            MessagingCenter = messaging;
            InitializeComponent();
        }

        private async void AddClinicClicked(object sender, EventArgs e)
        {
            var NewClinic = new Models.Clinic
            {
                ClinicId = new Random().Next(15,300),
                City = ClinicCity,
                ClinicName = ClinicName
            };

            var clinics = Application.Current.Properties["Clinics"] as List<Clinic>;

            clinics.Add(NewClinic);

            var notclinics = Application.Current.Properties["Clinics"];
            Application.Current.Properties["Clinics"] = clinics;

            await Navigation.PushAsync(new LocationsScreen(new Person
            {
                Role = "admin",
                Location = null
            }, MessagingCenter));
        }
    }
}