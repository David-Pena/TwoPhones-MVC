using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwoPhones.Models.TableViewModels
{
    public class MessageTableViewModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
    }
}