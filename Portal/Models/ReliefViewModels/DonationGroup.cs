using System;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models.ReliefViewModels
{
    public class DonationGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }

        public int GoodsCount { get; set; }
    }
}
