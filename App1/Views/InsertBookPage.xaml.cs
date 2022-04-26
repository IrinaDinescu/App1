using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Tables;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertBookPage : ContentPage
    {
        public InsertBookPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false); 
            InitializeComponent();
        }

        async void saveNewBook(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(authorEntry.Text))
            {
                await DisplayAlert("Invalid", "Blank or WhiteSpace value is invalid!", "OK");
            }
            else
            {
                AddNewBook();
            }

        }

        async void AddNewBook()
        {
            await App.MyDatabase.CreateBook(new Book
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            });

           // await Navigation.PushAsync(new NavigationPage(new BooksListPage()));

        }
    }
}