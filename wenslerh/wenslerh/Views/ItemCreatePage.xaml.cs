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
                ID = Guid.NewGuid().ToString(),//give it a primary key
            };

            BindingContext = this;

        }

        async void OnSaveClicked(object sender, EventArgs e)
        {

            System.Diagnostics.Debug.Write("Savinging item " + newItem.Name);
            var item = (ItemCreatePage)BindingContext;
            await App.Database.SaveItemAsync(newItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
