using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherApp : ContentPage, INotifyPropertyChanged
    {
        public WeatherApp()
        {
            InitializeComponent();
            GetWeatherInfo();
            BindingContext = this;
        }

        private string _gamervejr;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string gamervejr
        {
            get { return _gamervejr; }
            set { _gamervejr = value; OnPropertyChanged("gamervejr"); }
        }

        private string Location = "Odense";

        private async void GetWeatherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid=4efd146048741e1c3dfc3ba94486df43&units=metric";

            var result = await ApiWeatherCaller.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response);
                    descriptionTxt.Text = weatherInfo.weather[0].description.ToUpper();
                    iconImg.Source = $"w{weatherInfo.weather[0].icon}";
                    cityTxt.Text = weatherInfo.name.ToUpper();
                    temperatureTxt.Text = weatherInfo.main.temp.ToString("0");
                    humidityTxt.Text = $"{weatherInfo.main.humidity}%";
                    windTxt.Text = $"{weatherInfo.wind.speed} m/s";
                    cloudinessTxt.Text = $"{weatherInfo.clouds.all}%";

                    //var dt = new DateTime().ToUniversalTime().AddSeconds(weatherInfo.dt);
                    //dateTxt.Text = dt.ToString("dddd, MMM dd").ToUpper();

                    //var day = new DateTime().Day;
                    DateTime test = DateTime.Now;


                    

                    //DayOfWeek wk = DateTime.Today.DayOfWeek;

                    //int day = 4;
                    //switch (day)
                    //{
                    //    case 1:
                    //        day = "Monday";
                    //        break;
                    //    case 2:
                    //        day = "Tuesday";
                    //        break;
                    //    case 3:
                    //        day = "Wednesday";
                    //        break;
                    //    case 4:
                    //        day = "Thursday";
                    //        break;
                    //    case 5:
                    //        day = "Friday";
                    //        break;
                    //    case 6:
                    //        day = "Saturday";
                    //        break;
                    //    case 7:
                    //        day = "Sunday";
                    //        break;
                    //}

                    var dt = new DateTime().ToUniversalTime().AddSeconds(weatherInfo.dt);
                    //var dt = new DateTime(weatherInfo.dt * 1000);
                    dateTxt.Text = dt.ToString(test.ToString("ddd") + ", MMMM, dd").ToUpper();
                    //dateTxt.Text = dt.ToString("dddd, MMMM, dd").ToUpper();

                    if (weatherInfo.main.temp >= 1 && weatherInfo.main.temp <= 10)
                            {
                                temperatureTxt.TextColor = Color.White;
                                gamervejr = "It is gamer weather";
                            }
                            else if (weatherInfo.main.temp <= 0)
                            {
                                temperatureTxt.TextColor = Color.Turquoise;
                                gamervejr = "It is gamer weather with a scarf on";
                            }
                            else if (weatherInfo.main.temp >= 11 && weatherInfo.main.temp <= 20)
                            {
                                temperatureTxt.TextColor = Color.Orange;
                                gamervejr = "It is gamer weather with";
                            }
                            else
                            {
                                temperatureTxt.TextColor = Color.Red;
                                gamervejr = "It is gamer weather with aircon"; 
                            }

                            //GetForecast();

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Weather Info", ex.Message, "OK");
                }

            }
            else
            {
                await DisplayAlert("Weather Info", "No Weather Info Found", "Ok");
            }


        }



        public void SesØjne(object sender, System.EventArgs e)
        {
                gamer.Opacity = 100;
            //    Random r = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    int one = r.Next(0, 255);
            //    int two = r.Next(0, 255);
            //    int three = r.Next(0, 255);
            //    int four = r.Next(0, 255);

            //    gamer.TextColor = Color.FromRgba(one, two, three, four);
            //}
        }

    }
}