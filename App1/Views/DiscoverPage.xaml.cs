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
    public partial class DiscoverPage : ContentPage
    {
        public DiscoverPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.MyDatabase.ReadBooks();
            }
            catch
            {

            }
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tappedEvgs = e as TappedEventArgs;
            var data = tappedEvgs.Parameter;

            Tables.Book b = (Tables.Book)data;

            await Navigation.PushAsync((new BookDetailsPage(b.Id)));


            // DisplayAlert("Hi", b.Id.ToString(), "OK");
        }
    }
}