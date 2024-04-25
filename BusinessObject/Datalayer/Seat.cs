using System;
using System.Collections.Generic;

namespace BusinessObject.Datalayer
{
    public partial class Seat
    {
        public Seat()
        {
            TicketDetails = new HashSet<TicketDetail>();
        }

        public int SeatId { get; set; }
        public string SeatColumn { get; set; }
        public long? SeatRow { get; set; }
        public int? SeatStatus { get; set; }
        public long? SeatType { get; set; }

        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
