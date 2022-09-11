using Portal.Models.Donation;
using System.Collections.Generic;

namespace Portal.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<Good> Goods { get; set; }
    }
}
