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
            ((App)App.Current).ResumeAtItemId = -1;

            //if the database is empty, fill it!!!
            await App.Database.Initialize();

            listview.ItemsSource = await App.Database.GetItemsAsync();

        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemDetailPage
            {
                BindingContext = new Item()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtItemId = (e.SelectedItem as Item).ID;
            Debug.WriteLine("setting ResumeAtItemId = " + (e.SelectedItem as Item).ID);

            await Navigation.PushAsync(new ItemDetailPage
            {
                BindingContext = e.SelectedItem as Item
            });
        }
    }
}

