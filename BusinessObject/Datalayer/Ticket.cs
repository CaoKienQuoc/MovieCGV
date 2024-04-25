using System;
using System.Collections.Generic;

namespace BusinessObject.Datalayer
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public double? Price { get; set; }
        public int? TicketType { get; set; }
        public int? AccountId { get; set; }
        public int? TicketDetailsId { get; set; }

        public virtual Account Account { get; set; }
        public virtual TicketDetail TicketDetails { get; set; }
    }
}
