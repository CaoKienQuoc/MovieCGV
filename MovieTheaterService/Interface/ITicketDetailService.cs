using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Interface
{
    public interface ITicketDetailService
    {
        public List<TicketDetail> GetAllTick(int ticketDetailsId);
        public TicketDetail GetDetailTicketByDetailID(int? id);
        public decimal UpdateTicketDetail(TicketDetail ticketDetail, int? ticketId);
        public TicketDetail GetTicketDetailByTicketId(int? ticketId);
        public void AddTicketDetail(TicketDetail ticketDetail);
    }
}
