using System;
using Xamarin.Forms;
using App1.Views;
using Xamarin.Forms.Xaml;
using System.IO;
using App1.Tables;

namespace App1
{
    public partial class App : Application
    {
        private static SQLiteHelper db;

        private static RegUserTable user;

      
        public static SQLiteHelper MyDatabase
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "MyStore.db3"));
                }
                return db;

            }
        }

        internal static RegUserTable User { get => user; set => user = value; }

        public App()
        {
            InitializeComponent();

          

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
