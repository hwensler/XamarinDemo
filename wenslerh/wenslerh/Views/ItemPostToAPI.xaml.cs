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
        int SelectedCharacterTypeIndex;

        //create int for selected character level
        int SelectedCharacterLevel = 0;

        //create bool for random
        Boolean SelectedRandom = false;


        
		public ItemPostToAPI()
		{
			InitializeComponent ();
            BindingContext = this;

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
