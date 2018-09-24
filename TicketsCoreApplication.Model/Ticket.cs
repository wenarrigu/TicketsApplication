using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsCoreApplication.Model
{
    public class Ticket
    {
        public int TicketNumber { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public Category Category { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string Comment { get; set; }
    }
}
