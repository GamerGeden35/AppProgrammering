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
    public partial class CookieClicker : ContentPage
    {
        public CookieClicker()
        {
            InitializeComponent();
        }
        int count = 0;
        void Handle_Clicked_Inc(object sender, System.EventArgs e)
        {
            count++;
            label.Text = $"{count}";
            if (count % 2 != 0)
            {
                Cookie.ScaleTo(1, 20, Easing.Linear);
            }
            else
            {
                Cookie.ScaleTo(0.99, 20, Easing.Linear);
            }
        }
        void Handle_Clicked_Dec(object sender, EventArgs e)
        {
            count--;
            label.Text = $"{count}";
        }

        void Zoom(object sender, EventArgs e)
        {
            count++;
            label.Text = $"{count}";
            if (count % 2 != 0)
            {
                Cookie.ScaleTo(1, 20, Easing.Linear);
            }
            else
            {
                Cookie.ScaleTo(0.95, 20, Easing.Linear);
            }
        }
    }
}