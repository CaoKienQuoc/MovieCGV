using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Datalayer
{
    public partial class Movie
    {
        public Movie()
        {
            TicketDetails = new HashSet<TicketDetail>();
        }

        public int MovieId { get; set; }
        public string Actor { get; set; }
        public long? CinemaRoomId { get; set; }
        public string Content { get; set; }
        public string Director { get; set; }
        public long? Duration { get; set; }
        public DateTime? FromDate { get; set; }
        public string LargeImage { get; set; }
        public string MovieNameEnglish { get; set; }
        public string MovieNameVn { get; set; }
        public string MovieProductionCompamy { get; set; }
        public string SmallImage { get; set; }
        public int? Status { get; set; }
        public DateTime? ToDate { get; set; }
        public string Version { get; set; }
        

        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
