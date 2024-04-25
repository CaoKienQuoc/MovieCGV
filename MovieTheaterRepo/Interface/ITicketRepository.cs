using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using MovieTheaterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Interface
{
    public interface ITicketRepository
    {
        public List<Ticket> GetAllTicketByUserId(int? accountId);
        public Ticket GetTicketByID(int id);
        public bool AddTicket(Ticket ticket, TicketDetail ticketDetails);
        public void UpdateTicket(Ticket ticket);
        public Task<List<Ticket>> GetTicketsWithDetailsByAccountIdAsync(int? accountId);
    }
}
