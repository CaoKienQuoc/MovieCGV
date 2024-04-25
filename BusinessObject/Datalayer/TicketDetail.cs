using System;
using System.Collections.Generic;

namespace BusinessObject.Datalayer
{
    public partial class TicketDetail
    {
        public TicketDetail()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int TicketDetailsId { get; set; }
        public int SeatId { get; set; }
        public int FoodId { get; set; }
        public int MovieId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
