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
    public partial class LocationsScreen : ContentPage
    {
        private List<Clinic> Clinics { get; set; }
        private static List<Button> ClinicButtons { get; set; }
        public IMessagingCenter MessagingCenter { get; set; }
        public Person User { get; set; }
        public Clinic SelectedClinic { get; set; }
        public string ClinicLabel { get; set; }
        public LocationsScreen(Person user,IMessagingCenter messagingCenter)
        {
            User = user;
            MessagingCenter = messagingCenter;
            InitializeComponent();
            InitializeMessageCenter();
            GenerateClinicButtons();
        }

        private void GenerateClinicButtons()
        {
            Clinics = Application.Current.Properties["Clinics"] as List<Clinic>;
            ClinicButtons = new List<Button>();
            var stackLayout = new StackLayout();
            foreach(var clinic in Clinics)
            {
                GenerateClinicButton(clinic);
            }
            UpdateClinicButtons();
            var wtvr = "wtvr";
        }

        private void InitializeMessageCenter()
        {
            MessagingCenter.Subscribe<UpdateClinicMessage>(this, "Update Clinic", (updateClinicMessage) =>
            {
                var ClinicCity = updateClinicMessage.UpdatedClinic.City;
                var ClinicName = updateClinicMessage.UpdatedClinic.ClinicName;

                var updatedClinic = new Clinic
                {
                    ClinicId = 983,
                    ClinicName = ClinicName,
                    City = ClinicCity
                };

                //Update List of buttons with new UpdatedClinic
                ReplaceClinic(updatedClinic);
                //send updatedClinic to db
            });
            MessagingCenter.Subscribe<NewClinicMessage>(this, "New Clinic", (newClinicMessage) => 
            {
                var ClinicCity = newClinicMessage.NewClinic.City;
                var ClinicName = newClinicMessage.NewClinic.ClinicName;

                var newClinic = new Clinic
                {
                    ClinicId = 983,
                    ClinicName = ClinicName,
                    City = ClinicCity
                };
                GenerateClinicButton(newClinic);
                UpdateClinicButtons();
                //add clinic to list of buttons 
                //add clinic to db
            });
        }

        private void ReplaceClinic(Clinic UpdateClinic)
        {
            var clinic = Clinics.FirstOrDefault(foundClinic => foundClinic.ClinicId == UpdateClinic.ClinicId);

            if (clinic != null)
            {
                Clinics.Remove(clinic);
                Clinics.Add(UpdateClinic);
                GenerateClinicButton(clinic);
                UpdateClinicButtons();
            }

        }

        private void GenerateClinicButton(Clinic clinic)
        {
            var button = new Button();
            button.Text = $"{clinic.ClinicName}-{clinic.City}";
            button.Clicked += ClinicButtonClicked;
            ClinicButtons.Add(button);
            
        }

        private void UpdateClinicButtons()
        {
            var stackLayout = new StackLayout();

            stackLayout.Children.Add(new Label 
            {
                Text = ClinicLabel
            });

            foreach(var button in ClinicButtons)
            {
                stackLayout.Children.Add(button);
            }

            if(User.Role == "admin")
            {
                var addClinicButton = new Button();
                addClinicButton.Text = "Add Clinic";
                addClinicButton.Clicked += AddClinicClicked;
                stackLayout.Children.Add(addClinicButton);
            }

            this.Content = stackLayout;
        }
        private async void AddClinicClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewClinicScreen(MessagingCenter));
        }

        private async void ClinicButtonClicked(object sender, EventArgs e)
        {
            var clinicBtn = sender as Button;
            var clinicLabel = clinicBtn.Text;

            var clinicLabelContents = clinicLabel.Split('-');
            var clinicName = $"{clinicLabelContents[0]}";
            var clinicCity = clinicLabelContents[1];

            var foundClinic = Clinics.FirstOrDefault(clinic => clinic.ClinicName == clinicName && clinic.City == clinicCity);

            if(User.Role == "admin")
            {
                var selectedClinic = new Clinic 
                {
                    ClinicId = foundClinic.ClinicId,
                    ClinicName = clinicName,
                    City = clinicCity
                };
                SelectedClinic = selectedClinic;

                await Navigation.PushAsync(new UpdateClinicScreen(MessagingCenter, SelectedClinic));
            }
            else
            {
                ClinicLabel = clinicLabel;
                UpdateClinicButtons();
            }
        }
    }
}