using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using wenslerh.Models;
using wenslerh.ViewModels;

//a page for creating new items 

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

                //give it a primary key
                ID = Guid.NewGuid().ToString(),
            };

            BindingContext = this;

        }

        //when you click save
        async void OnSaveClicked(object sender, EventArgs e)
        {
            await App.Database.SaveItemAsync(newItem);
            await Navigation.PopAsync();
        }

        //when you click cancel
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
