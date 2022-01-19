using AwesomeApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

        }
        
         async private void LoginUser(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<ReqUserTable>().Where(u => u.Username.Equals(InputUser.Text) && u.Password.Equals(InputPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                //App.Current.MainPage = new NavigationPage(new Home());
                App.Current.MainPage = new MainPage();
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Vibration.Vibrate(100);
                    var result = await this.DisplayAlert("Error", "Username or Password is incorrect", "OK", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                });
            }
        }

        async private void SignUpUser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}