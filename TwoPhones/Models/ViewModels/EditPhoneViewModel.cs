using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwoPhones.Models.ViewModels
{
    public class EditPhoneViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Balance")]
        public string Balance { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "IsPublic")]
        public string IsPublic { get; set; }
    }
}