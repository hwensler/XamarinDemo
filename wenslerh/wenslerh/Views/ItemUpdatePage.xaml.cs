using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using wenslerh.Models;
using wenslerh.ViewModels;

namespace wenslerh.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class ItemUpdatePage : ContentPage
	{

        //declare the new item to store updated variables
        public Item thisItem { get; set; }

        public ItemUpdatePage ()
		{
			InitializeComponent ();
		}

        //when passed an item
        public ItemUpdatePage(Item item)
        {

            System.Diagnostics.Debug.WriteLine("updating item: " + item.Name);

            InitializeComponent();
            thisItem = item;

            Title = "Update an Item";

            BindingContext = this;
        }

        //when you click save
        async void OnSaveClicked(object sender, EventArgs e)
        {

            await App.Database.SaveItemAsync(thisItem);
            await Navigation.PushAsync(new ItemsPage());
        }

        //when you click cancel
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}
