using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using App1.Tables;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

       

        async void goToSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new RegisterPage()));
        }

        async void login(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbPath);

            var myQuery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if(myQuery != null)
            {
                // App.Current.MainPage = new NavigationPage(new HomePage());
                App.User = myQuery;
                App.Current.MainPage = new NavigationPage(new Tabbed());
                
 
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {

                    var result = await this.DisplayAlert("Error", "Username or Password not found!", "OK", "Cancel");

                    if (result)
                       // await Navigation.PushAsync(new NavigationPage(new LoginPage()));
                        await Navigation.PushAsync((new LoginPage()));
                    else
                    {
                       // await Navigation.PushAsync(new NavigationPage(new LoginPage()));
                        await Navigation.PushAsync((new LoginPage()));
                    }

                });
            }
        }
    }
}