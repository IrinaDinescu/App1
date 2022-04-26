using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        async void insertNewBook(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new InsertBookPage()));
        }
        async void seeSavedBooks(object sender, EventArgs e)
        {
            await Navigation.PushAsync((new FavoritesPage()));
        }
    }
}