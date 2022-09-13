using System.Collections.Generic;

namespace Portal.Models
{
    public class AidType
    {
        public int AidTypeID { get; set; }
        public string Name { get; set; }

        public ICollection<Disaster> Disasters { get; set; }
    }
}
