using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsInCloud.App.Models;
using Xamarin.Forms;

namespace SensorsInCloud.App
{
    public partial class MainPage : ContentPage
    {
        private ConnectionManager _connectionManager;
        private MainPageModel _pageModel;
        public MainPage()
        {
            InitializeComponent();
            _connectionManager=new ConnectionManager();
            _pageModel=new MainPageModel();
            BindingContext = _pageModel;
            Image1.Source = Device.OnPlatform(
                iOS: ImageSource.FromFile("Images/humidity.jpg"),
                Android: ImageSource.FromFile("humidity.jpg"),
                WinPhone: ImageSource.FromFile("humidity.png"));

            Image2.Source = Device.OnPlatform(
                iOS: ImageSource.FromFile("Images/temperature.jpg"),
                Android: ImageSource.FromFile("temperature.jpg"),
                WinPhone: ImageSource.FromFile("temperature.png"));

            Download();
        }

        public async void Download()
        {
          List<SensorLine> lines=await  _connectionManager.GetSensors();

            if (lines.Count > 0)
            {
                _pageModel.Value1 = lines[0].Value1.Value;
                _pageModel.Value2 = lines[0].Value2.Value;
            }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Download();
        }
    }
}
