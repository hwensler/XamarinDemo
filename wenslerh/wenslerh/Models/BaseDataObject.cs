using System;
using wenslerh.Helpers;

namespace wenslerh.Models
{
    public class BaseDataObject : ObservableObject
    {
        public BaseDataObject()
        {
            baseId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Id for item
        /// </summary>
        public string baseId { get; set; }

        /// <summary>
        /// Azure created at time stamp
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Azure UpdateAt timestamp for online/offline sync
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Azure version for online/offline sync
        /// </summary>
        public string AzureVersion { get; set; }
    }
}
