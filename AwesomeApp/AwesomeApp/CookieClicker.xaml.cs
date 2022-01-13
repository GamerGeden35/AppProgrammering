using AwesomeApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
        int cookies = 0;
        void Handle_Clicked_Inc(object sender, System.EventArgs e)
        {
            cookies++;
            counter.Text = $"{cookies}";
            if (cookies % 2 != 0)
            {
                Cookie.ScaleTo(1, 20, Easing.Linear);
            }
            else
            {
                Cookie.ScaleTo(0.99, 20, Easing.Linear);
            }
        }

        async private void SaveScore(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScoreDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<ScoresTable>().Where(s => s.Score.Equals(cookies)).FirstOrDefault();

            //var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            //var db = new SQLiteConnection(dbpath);
            //var myquery = db.Table<ReqUserTable>().Where(u => u.Username.Equals(InputUser.Text) && u.Password.Equals(InputPassword.Text)).FirstOrDefault();
        }

    }
}