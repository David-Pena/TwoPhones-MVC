using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwoPhones.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string Identification { get; set; }

        public string Role { get; set; }
    }
}