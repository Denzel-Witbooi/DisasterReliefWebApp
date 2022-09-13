﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models.Donation
{
    public class Monetary
    {
        public int MonetaryID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Donation Amount")]
        public decimal DonationAmount { get; set; }

        [DisplayFormat(NullDisplayText = "anonymous")]
        [Display(Name = "Donor Name")]
        public string DonorName { get; set; }

    }
}
