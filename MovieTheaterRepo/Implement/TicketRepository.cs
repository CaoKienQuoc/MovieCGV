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
    public class TicketRepository : ITicketRepository
    {
        public bool AddTicket(Ticket ticket, TicketDetail ticketDetails)
        => TicketDAO.Instance.AddTicket(ticket, ticketDetails);

        public List<Ticket> GetAllTicketByUserId(int? accountId)
        =>TicketDAO.Instance.GetAllTicketByUserId(accountId);

        public Ticket GetTicketByID(int id)
        =>TicketDAO.Instance.GetTicketByID(id);

        public Task<List<Ticket>> GetTicketsWithDetailsByAccountIdAsync(int? accountId)=>TicketDAO.Instance.GetTicketsWithDetailsByAccountIdAsync(accountId);
        public void UpdateTicket(Ticket ticket)
        => TicketDAO.Instance.UpdateTicket(ticket);
    }
}
