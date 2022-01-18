using AwesomeApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class CookieClicker : ContentPage, INotifyPropertyChanged
    {
        public CookieClicker()
        {
            InitializeComponent();
        }

        int cookies = 0;

        //private int _cookies = 0;

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName)); 
        //}

        //public int cookies
        //{
        //    get { return _cookies; }
        //    set { _cookies = value; OnPropertyChanged("cookies"); }
        //}
        

        void Handle_Clicked_Inc(object sender, System.EventArgs e)
        {
            cookies++;
            //Xamarin.Essentials.Vibration.Cancel();
            Vibration.Vibrate(55);
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