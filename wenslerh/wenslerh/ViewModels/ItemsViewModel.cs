/**
 * A view model for the items page.
 * **/
 using System;
using System.Diagnostics;
using Xamarin.Forms;
using wenslerh.Views;
using wenslerh.Models;
using wenslerh;

namespace App11
{
    public class ItemsViewModel : ContentPage
    {
        ListView listView;

        public ItemsViewModel()
        {
            Title = "Items Page";
            Icon = Device.OnPlatform(null, "plus.png", "plus.png")

            var toolbarItem = new ToolbarItem
            {
                Text = "Create"
            };

            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ItemDetailPage
                {
                    BindingContext = new Item()
                });
            };

            ToolbarItems.Add(toolbarItem);

            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var name = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    name.SetBinding(Label.TextProperty, "Name");

                    var strength = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    strength.SetBinding(Label.TextProperty, "Strength");

                    var description = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    description.SetBinding(Label.TextProperty, "Description");


                    var stackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { name, strength }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };


            listView.ItemSelected += async (sender, e) =>
            {
                ((App)App.Current).ResumeAtItemId = (e.SelectedItem as Item).ID;
                Debug.WriteLine("setting ResumeAtItemId = " + (e.SelectedItem as Item).ID);

                await Navigation.PushAsync(new ItemDetailPage
                {
                    BindingContext = e.SelectedItem as Item
                });
            };

            Content = listView;

        }
    }
}


