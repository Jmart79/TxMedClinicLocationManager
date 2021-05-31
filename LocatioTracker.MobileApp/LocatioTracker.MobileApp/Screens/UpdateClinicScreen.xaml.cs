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
    public partial class UpdateClinicScreen : ContentPage
    {
        public string ClinicCity { get; set; }
        public string ClinicName { get; set; }
        private int ClinicId { get; set; }
        protected IMessagingCenter MessagingCenter { get; set; }
        public UpdateClinicScreen(IMessagingCenter messaging,Clinic clinic)
        {
            BindingContext = this;
            ClinicCity = clinic.City;
            ClinicName = clinic.ClinicName;
            ClinicId = clinic.ClinicId;
            MessagingCenter = messaging;
            InitializeComponent();
        }



        private async void UpdateClinicClicked(object sender, EventArgs e)
        {
            var UpdatedClinic = new Models.Clinic
            {
                ClinicId = ClinicId,
                City = ClinicCity,
                ClinicName = ClinicName
            };

            var clinics = Application.Current.Properties["Clinics"] as List<Clinic>;

            var foundClinic = clinics.FirstOrDefault(clinic => clinic.ClinicId == UpdatedClinic.ClinicId);

            if(foundClinic != null)
            {
                clinics.Remove(foundClinic);
                clinics.Add(UpdatedClinic);
            }

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