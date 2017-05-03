
using SQLite;

namespace wenslerh.Models
{
    public class Item : BaseDataObject
	{
        //make the ID the pk
        [PrimaryKey]
        public string ID { get; set; }

        //the name of the item
        public string Name { get; set; }

        //a description of the item
		public string Description { get; set; }

        //the strength of the item
        public int Strength { get; set; }

    }
}
