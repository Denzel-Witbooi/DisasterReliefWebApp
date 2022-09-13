using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class AidType
    {
        [Display(Name = "Aid Type")]
        public int AidTypeID { get; set; }

        [Display(Name = "Aid Type")]
        public string Name { get; set; }

        public ICollection<Disaster> Disasters { get; set; }
    }
}
