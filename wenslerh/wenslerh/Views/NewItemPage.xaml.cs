using System;

using wenslerh.Models;

using Xamarin.Forms;

namespace wenslerh.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();

            Item = new Item
            {
                Name = "Item name",
                Description = "This is a nice description",
                Strength= 0
			};

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopToRootAsync();
		}
	}
}