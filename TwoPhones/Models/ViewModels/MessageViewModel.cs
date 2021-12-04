using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwoPhones.Models.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "From")]
        public string From { get; set; }

        [Required]
        [Display(Name = "To")]
        public string To { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}