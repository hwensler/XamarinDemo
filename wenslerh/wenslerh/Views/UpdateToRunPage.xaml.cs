using System;

using wenslerh.Models;
using wenslerh.Services;
using Xamarin.Forms;

namespace wenslerh.Views
{
    public partial class UpdateToRunPage : ContentPage
    {
        public int runNumber { get; set; }

        public UpdateToRunPage()
        {
            InitializeComponent();

            runNumber = 1;

            BindingContext = this;
        }

        async void Update(object sender, EventArgs e)
        {
            var apiGetter = new ApiGetter();
            var items = await apiGetter.Get(runNumber);
            apiGetter.UpdateDatabase(items);
            await Navigation.PopToRootAsync();
        }
    }
}