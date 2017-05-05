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

            InitializeComponent();
            thisItem = item;

            Title = "Update an Item";

            thisItem = new Item
            {
                Name = thisItem.Name,
                Description = thisItem.Description,
                Strength = thisItem.Strength,

                //remember its primary key
                ID = thisItem.ID,
            };

            BindingContext = this;
        }

        //when you click save
        async void OnSaveClicked(object sender, EventArgs e)
        {

            System.Diagnostics.Debug.Write("Savinging item " + thisItem.Name);
            var item = BindingContext;
            await App.Database.SaveItemAsync(thisItem);
            await Navigation.PopAsync();
        }

        //when you click cancel
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}
