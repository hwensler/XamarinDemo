/**
 * A view model for the itemsdetail page.
 * **/
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using wenslerh.Helpers;
using wenslerh.Models;
using wenslerh.Views;

using Xamarin.Forms;

namespace wenslerh.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}