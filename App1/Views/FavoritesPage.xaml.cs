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
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FavoritesBooks.db");
                var db = new SQLiteConnection(dbPath);

                
                var myQuery = db.Table<FavoriteBookTable>().Where(book => book.Username.Equals(App.User.UserName));
                var k = myQuery.Count();
              

                if(myQuery != null)
                {
                   List<int> favoriteBooksIds = new List<int>(myQuery.Count());
                   foreach (var favorites in myQuery)
                    {
                        favoriteBooksIds.Add(favorites.BookId);
                    }

                   List<Book> favoriteBooks = new List<Book>(myQuery.Count());
                   foreach(var id in favoriteBooksIds)
                    {
                        var list = await App.MyDatabase.getBookById(id);
                        var b = list.Where(u => u.Id.Equals(id)).FirstOrDefault();
                        favoriteBooks.Add(b);
                    }

                    myCollectionView.ItemsSource = favoriteBooks;

                }

            }
            catch
            {

            }
        }
    }
}