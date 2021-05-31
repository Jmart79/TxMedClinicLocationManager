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
    public partial class NewClinicScreen : ContentPage
    {
        public string ClinicCity { get; set; }
        public string ClinicName { get; set; }
        protected IMessagingCenter MessagingCenter { get; set; }
        public NewClinicScreen(IMessagingCenter messaging)
        {
            InitializeComponent();
            MessagingCenter = messaging;
        }



        private void CreateClinicClicked(object sender, EventArgs e)
        {
            SendNewClinicMessage();
        }

        private void SendNewClinicMessage()
        {
            var newClinic = new Clinic();
            newClinic.City = ClinicCity;
            newClinic.ClinicName = ClinicName;
            MessagingCenter.Send<NewClinicMessage>(new NewClinicMessage()
            {
                NewClinic = newClinic
            }, "New Clinic") ;
        }
    }
}