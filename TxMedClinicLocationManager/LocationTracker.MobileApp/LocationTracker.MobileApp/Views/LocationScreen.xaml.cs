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
        public LocationScreen()
        {
            InitializeComponent();
        }
    }
}