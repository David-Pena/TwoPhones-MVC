using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwoPhones.Models.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "ExpirationDate")]
        [StringLength(5, ErrorMessage = "Invalid Date, Only 5 characters accepted!")]
        public string ExpirationDate { get; set; }

        [Required]
        [Display(Name = "CVV")]
        [StringLength(3, ErrorMessage = "Invalid CVV, Only 3 characters accepted!")]
        public string CVV { get; set; }

        [Required]
        [Display(Name = "Identification")]
        public string Identification { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}