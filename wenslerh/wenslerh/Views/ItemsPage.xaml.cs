using System;
using Xamarin.Forms;
using System.Diagnostics;
using wenslerh.Models;
using System.Runtime.CompilerServices;
using wenslerh.ViewModels;

namespace wenslerh.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //reset the resume id 
            ((App)App.Current).ResumeAtItemId = "";

            //if the database is empty, fill it!!!
            await App.Database.Initialize();

            listview.ItemsSource = await App.Database.GetItemsAsync();
            //var apiGetter = new wenslerh.Services.ApiGetter();
            //listview.ItemsSource = await apiGetter.Get();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemCreatePage());
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtItemId = (e.SelectedItem as Item).ID;
            Debug.WriteLine("setting ResumeAtItemId = " + (e.SelectedItem as Item).ID);

            //load items detail page with the selected item as the item!
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(e.SelectedItem as Item)));
        }

        async void UpdateToRun(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateToRunPage());
        }
    }
}

