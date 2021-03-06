﻿
/**
 * A view model for the main menu.
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
    public class MenuPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<MenuPage> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        //data will come from Main Menu
        wenslerh.Services.MainMenu data;

        public MenuPageViewModel()
        {
            Title = "Navigate Your Quest";
            Items = new ObservableRangeCollection<MenuPage>();
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
                data = new wenslerh.Services.MainMenu();

                //take the loaded data and put it where we can render it
                var items = data.pages;
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