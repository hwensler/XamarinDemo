using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wenslerh.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wenslerh.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPostToAPI : ContentPage
    {

        //a list for CharacterType items
        List<String> CharacterTypes = new List<string>()
        {
            "Fighter",
            "Cleric",
            "Thief"
        };


        //create string for selected character
        public int SelectedCharacterTypeIndex { get; set; }

        //create int for selected character level
        public int SelectedCharacterLevel { get; set; }

        //create bool for random
        public Boolean SelectedRandom { get; set; }


        
		public ItemPostToAPI()
		{
			InitializeComponent ();
            BindingContext = this;
            this.TypePicker.Items.Clear();
            foreach (var type in CharacterTypes)
            {
                this.TypePicker.Items.Add(type);
            }


        }

        async void Update(object sender, EventArgs e)
        {
            //create an int for selectedrandom
            int SelectedRandomInt;

            //convtert that bool to an int
            if (SelectedRandom == false)
            {
                SelectedRandomInt = 0;
            }
            else
            {
                SelectedRandomInt = 1;
            }

            //back to API stuff
            var apiGetter = new ApiGetter();
            var items = await apiGetter.Post(SelectedRandomInt, CharacterTypes[SelectedCharacterTypeIndex], SelectedCharacterLevel);
            apiGetter.UpdateDatabase(items);
            await Navigation.PopToRootAsync();
        }
    }
}
