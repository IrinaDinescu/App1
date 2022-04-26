using App1.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //COmentariu
    public partial class BookDetailsPage : ContentPage
    {
        private int id;
        public BookDetailsPage(int bookId)
        {
            InitializeComponent();
            id = bookId;

            nameEntry.Text = id.ToString();

            readBookFromdb();

           
        }

        async void readBookFromdb()
        {
            var list = await App.MyDatabase.getBookById(id);
            var b = list.Where(u => u.Id.Equals(id)).FirstOrDefault();

            nameEntry.Text = b.Name;
            authorEntry.Text = b.Author;
        }

        private void addToFavorites(object sender, EventArgs e)
        {

        }
    }
}