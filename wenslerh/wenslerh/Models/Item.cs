namespace wenslerh.Models
{
    public class Item : BaseDataObject
	{
        public int id { get; set; }

		string name = string.Empty;
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

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
