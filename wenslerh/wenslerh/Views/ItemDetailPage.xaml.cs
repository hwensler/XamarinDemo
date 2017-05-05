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

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var item = (Item)BindingContext;
                await App.Database.SaveItemAsync(item);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var item = (Item)BindingContext;
                await App.Database.DeleteItemAsync(item);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

        }

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

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtItemId = (e.SelectedItem as Item).ID;

            //load items detail page with the selected item as the item!
            await Navigation.PushAsync(new ItemUpdatePage(e.SelectedItem as Item));
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
