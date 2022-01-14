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

        private void SaveScore(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScoreDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<ScoresTable>();

            var score = new ScoresTable()
            {
                Score = cookies
            };
            db.Insert(score);

        }

        void ResumeGame_Clicked(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScoreDatabase.db");
            var db = new SQLiteConnection(dbpath);
            cookies = db.Table<ScoresTable>().Max(s => s.Score);
        }



    }
}