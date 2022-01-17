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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }
         
         void RegisterUser(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<ReqUserTable>();

            var item = new ReqUserTable()
            {
                Username = InputUsername.Text,
                Password = InputUserPassword.Text,
                Email = InputUserEmail.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (InputUsername.Text != null && InputUserPassword.Text != null && InputUserEmail.Text != null)
                {   
                var result = await this.DisplayAlert("Success", "User Created", "OK", "Cancel");
                if (result)
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    Vibration.Vibrate(100);
                    await this.DisplayAlert("Error", "One of the fields is not filled correctly", "OK", "Cancel");

                }

            });

        }

        async private void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}