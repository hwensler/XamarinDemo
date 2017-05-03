
using SQLite;

namespace wenslerh.Models
{
    public class Item : BaseDataObject
	{

        public string Name { get; set; }

        //a description of the item
		public string Description { get; set; }

        //the strength of the item
        public int Strength { get; set; }

    }
}
