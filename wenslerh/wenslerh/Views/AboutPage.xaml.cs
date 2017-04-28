
using Xamarin.Forms;
using System;

namespace wenslerh.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            //the entire string display is below. it displays the current datetime as well as static strings
            entireDisplay.Text = "CPSC - 5910 - SQ\nStudent - Heather Wensler\n" + DateTime.Now.ToString() + "\nCode Review - Jonathan Adler";
        }
    }
}
