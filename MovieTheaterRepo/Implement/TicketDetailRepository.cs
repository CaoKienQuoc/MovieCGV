using BusinessObject.Datalayer;
using MovieTheaterDAO;
using MovieTheaterRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Implement
{
    public class TicketDetailRepository : ITicketDetailRepository
    {
        public void AddTicketDetail(TicketDetail ticketDetail) => TicketDetailDAO.Instance.AddTicketDetail(ticketDetail);

        public List<TicketDetail> GetAllTick(int ticketDetailsId)
            =>TicketDetailDAO.Instance.GetAllTick(ticketDetailsId);


        public TicketDetail GetDetailTicketByDetailID(int? id)
            =>TicketDetailDAO.Instance.GetDetailTicketByDetailID(id);

        public TicketDetail GetTicketDetailByTicketId(int? ticketId)
            =>TicketDetailDAO.Instance.GetDetailTicketByDetailID(ticketId);

        public decimal UpdateTicketDetail(TicketDetail ticketDetail, int? ticketId)
            =>TicketDetailDAO.Instance.UpdateTicketDetail(ticketDetail, ticketId);
    }
}
