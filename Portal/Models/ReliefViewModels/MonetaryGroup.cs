using System;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models.ReliefViewModels
{
    public class MonetaryGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }

        public int MonetaryCount { get; set; }
    }
}
