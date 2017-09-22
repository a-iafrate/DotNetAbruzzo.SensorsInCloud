using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SensorsInCloud.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Image1.Source = Device.OnPlatform(
                iOS: ImageSource.FromFile("Images/humidity.jpg"),
                Android: ImageSource.FromFile("humidity.jpg"),
                WinPhone: ImageSource.FromFile("humidity.png"));

            Image2.Source = Device.OnPlatform(
                iOS: ImageSource.FromFile("Images/temperature.jpg"),
                Android: ImageSource.FromFile("temperature.jpg"),
                WinPhone: ImageSource.FromFile("temperature.png"));
        }
    }
}
