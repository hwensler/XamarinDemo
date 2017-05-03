using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }
	}
}
