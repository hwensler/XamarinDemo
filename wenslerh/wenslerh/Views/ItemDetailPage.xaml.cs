using System;
using wenslerh.ViewModels;
using wenslerh.Models;
using Xamarin.Forms;

namespace wenslerh.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();



        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    //reset the resume id 
        //    ((App)App.Current).ResumeAtItemId = "";

        //    //if the database is empty, fill it!!!
        //    await App.Database.Initialize();

        //    StackLayout.ItemsSource = await App.Database.GetItemsAsync();

        //}

        public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (ItemDetailViewModel)BindingContext;
            await App.Database.SaveItemAsync(item.Item);
            await Navigation.PopAsync();
        }

        async void OnUpdateClicked(object sender, EventArgs e)
        {
            var item = (ItemDetailViewModel)BindingContext;

            //load items detail page with the selected item as the item!
            await Navigation.PushAsync(new ItemUpdatePage(item.Item));
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (ItemDetailViewModel)BindingContext;
            await App.Database.DeleteItemAsync(item.Item);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
