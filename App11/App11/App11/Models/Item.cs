/**
 * Items class - used for items in this DND game
 * **/

namespace App11.Models
{
    public class Item : BaseDataObject
    {
        //the name of the item
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        //a description of the item
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        //the strength of the item
        public int Strength { get; set; }

    }
}
