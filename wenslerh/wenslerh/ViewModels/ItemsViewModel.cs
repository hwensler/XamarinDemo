/**
 * A view model for the items page.
 * **/
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using wenslerh.Helpers;
using wenslerh.Models;
using wenslerh.Views;
using wenslerh.Services;

using Xamarin.Forms;

namespace wenslerh.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        //data will come from ItemsPage
        wenslerh.Services.ItemsDatabase AllItems;


        public ItemsViewModel()
        {
            Title = "Look at all the items!";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                //load the data
                AllItems = new wenslerh.Services.ItemsDatabase();

                //take the loaded data and put it where we can render it
                var items = AllItems.items;
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}