using System;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models.ReliefViewModels
{
    public class DisasterGroup
    {

        [DataType(DataType.Date)]
        public DateTime? Active { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ActiveDate { get; set; }

        public int DisasterCount { get; set; }
    }
}
