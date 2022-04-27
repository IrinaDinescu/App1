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
        private Book book;
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
            book = b;


            nameEntry.Text = b.Name;
            authorEntry.Text = b.Author;
        }

        private void addToFavorites(object sender, EventArgs e)
        {
            // verificam daca cartea nu este cumva deja adaugata la favorite
            var dbPath1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FavoritesBooks.db");
            var db1 = new SQLiteConnection(dbPath1);
            var myQuery1 = db1.Table<FavoriteBookTable>().Where(book => book.Username.Equals(App.User.UserName) && book.BookId.Equals(this.book.Id)).FirstOrDefault();

            if(myQuery1 == null)
            {
                // daca nu gasim id-ul cartii putem sa o adaugam la favorite
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FavoritesBooks.db");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<FavoriteBookTable>();

                var item = new FavoriteBookTable()
                {
                    BookId = book.Id,
                    Username = App.User.UserName
                };

                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () =>
                {

                    var result = await this.DisplayAlert("Message", "Book added with succes!", "OK", "Cancel");
                    if (result)
                        await Navigation.PushAsync(new FavoritesPage());

                });
            }
            else
            {
                // cartea a fost gasita deja ca fiind adaugata
                // afisam un mesaj de eroare pentru informarea utilizatorului
                Device.BeginInvokeOnMainThread(async () =>
                {

                    var result = await this.DisplayAlert("Message", "Book Already added to your favorites!", "OK", "Cancel");

                });
            }
        }

      
        }
    }
