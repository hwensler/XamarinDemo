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
        //declare the new item
        public Item newItem { get; set; }

        public ItemCreatePage()
        {
            InitializeComponent();

            Title = "Create an Item";

            newItem = new Item
            {
                Name = "Item Name",
                Description = "Item Description",
                Strength = 0,
            };

            //give it a primary key
            newItem.ID = Guid.NewGuid().ToString();

            BindingContext = this;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {

            await App.Database.SaveItemAsync(newItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            await App.Database.DeleteItemAsync(newItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
