using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Interface
{
    public interface ITicketDetailRepository
    {
        public List<TicketDetail> GetAllTick(int ticketDetailsId);
        public TicketDetail GetDetailTicketByDetailID(int? id);
        public decimal UpdateTicketDetail(TicketDetail ticketDetail, int? ticketId);
        public TicketDetail GetTicketDetailByTicketId(int? ticketId);
        public void AddTicketDetail(TicketDetail ticketDetail);
    }
}
