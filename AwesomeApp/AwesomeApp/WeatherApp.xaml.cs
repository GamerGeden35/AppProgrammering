using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherApp : ContentPage
    {
        public WeatherApp()
        {
            InitializeComponent();
            SesØjne();

        }

        private string Location = "France";

        private async void GetWeatherInfo()
        {
            var url = $"api.openweathermap.org/data/2.5/weather?q={Location}&appid=4efd146048741e1c3dfc3ba94486df43";

            var result = await ApiWeatherCaller.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo
                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                await DisplaAlert("Weather Info", "No Weather Info Found", "Ok");
            }


        }


        public void SesØjne(object sender, System.EventArgs e)
        {
            gamer.Opacity = 1;
                Random r = new Random();
                int one = r.Next(0, 255);
                int two = r.Next(0, 255);
                int three = r.Next(0, 255);
                int four = r.Next(0, 255);

                gamer.TextColor = Color.FromRgba(one, two, three, four);
        }
    }
}