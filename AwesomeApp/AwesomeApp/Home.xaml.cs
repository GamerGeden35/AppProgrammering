using AwesomeApp.Tables;
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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            //LoginPage login = new LoginPage();
            ////string hello = "Hello " + Username;
            //if (Username != null)
            //{   
            //welcome.Text = "Hello {" + Username + "}";
            //}
            //else
            //{
            //    welcome.Text = "INTET NAVN";
            //}
        }
    }
}