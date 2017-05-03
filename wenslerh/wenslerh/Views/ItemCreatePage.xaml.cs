using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using wenslerh.Models;

namespace wenslerh.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemCreatePage : ContentPage
	{
		public ItemCreatePage ()
		{
			InitializeComponent ();

            Title = "Create an Item";

            var name = new Entry();
            name.SetBinding(Entry.TextProperty, "Name");

            var description = new Entry();
            description.SetBinding(Entry.TextProperty, "Name");

            var strength = new Entry();
            name.SetBinding(Entry.TextProperty, "Strength");

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
	}
}
