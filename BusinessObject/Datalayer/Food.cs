using System;
using System.Collections.Generic;

namespace BusinessObject.Datalayer
{
    public partial class Food
    {
        public Food()
        {
            TicketDetails = new HashSet<TicketDetail>();
        }

        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}
