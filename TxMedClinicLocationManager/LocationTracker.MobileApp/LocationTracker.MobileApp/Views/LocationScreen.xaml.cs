using LocationTracker.Data;
using LocationTracker.Data.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocationTracker.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationScreen : ContentPage
    {
        public IPerson User { get; protected set; }
        public List<Clinic> Clinics { get; protected set; }
        public List<Button> ClinicButtons { get; protected set; }
        protected IMessagingCenter MessageCenter { get; set; }
        public LocationScreen(IMessagingCenter messaging)
        {
            MessageCenter = messaging;
            InitializeComponent();
        }

        public LocationScreen(IPerson user)
        {
            InitializeComponent();
            InitializeMessagingCenter();
            User = user;
            InitializeLocationLabel();

        }

        private void InitializeLocationLabel()
        {
            var doctor = User as Doctor;
            SetLocationLabel(doctor.Location); 
        }
        private void SetLocationLabel(string location)
        {
            var doctor = User as Doctor;
            DoctorLocationLabel.Text = $"Your current location is: {location}";
        }

        private void InitializeMessagingCenter()
        {
            MessageCenter.Subscribe<NewClinicMessage>(this, "New Clinic",(newClinicMessage) => 
            {
                
                
            });
        }

        private void InitializeClinicsList()
        {
            ClinicButtons = GenerateClinicButtons();
            var stackLayout = new StackLayout();
            
        }

        private List<Button> GenerateClinicButtons()
        {
            var returnValue = new List<Button>();
            foreach(var clinic in Clinics)
            {
                var clinicButton = new Button();
                clinicButton.Text = $"{clinic.ClinicName} {clinic.City}";
                clinicButton.Clicked += ClinicButtonClicked;
                returnValue.Add(clinicButton);
            }

            return returnValue;
        }

        private async void ClinicButtonClicked(object sender, EventArgs e)
        {
            var clinicName = (sender as Button).Text;
            if(User.Role == "admin")
            {
                await Navigation.PushAsync(new NewClinicScreen(MessageCenter)) ;
            }
            else
            {
                var doctor = User as Doctor;
                doctor.Location = clinicName;
                InitializeLocationLabel();
                //Make UpdateDoctorLocation() call here
            }

        }
    }
}