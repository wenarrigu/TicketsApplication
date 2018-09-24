using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsCoreApplication.Model
{
    public class Filters
    {
        public int TicketNumber { get; set; }
        public int CategoryCode { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
