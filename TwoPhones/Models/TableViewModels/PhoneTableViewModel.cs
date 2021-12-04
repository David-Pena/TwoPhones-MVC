using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwoPhones.Models.TableViewModels
{
    public class PhoneTableViewModel
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Number { get; set; }
        public string Balance { get; set; }
        public string Status { get; set; }
        public string IsPublic { get; set; }
    }
}