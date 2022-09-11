﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models.Donation
{
    public class Good
    {
        public int GoodID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        public int NumberOfItems { get; set; }

        public string Description { get; set; }

        public string DonorName { get; set; }

        public int CategoryID { get; set; }
        public int DisasterID { get; set; }


        public Category Category { get; set; }

        public Disaster Disaster { get; set; }

    }
}
