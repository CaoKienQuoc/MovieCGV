using BusinessObject.Datalayer;
using MovieTheaterRepo.Interface;
using MovieTheaterService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Implement
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public bool AddTicket(Ticket ticket, TicketDetail ticketDetails)
        {
            return _ticketRepository.AddTicket(ticket, ticketDetails);
        }

        public List<Ticket> GetAllTicketByUserId(int? accountId)
        {
            return _ticketRepository.GetAllTicketByUserId(accountId);
        }

        public Ticket GetTicketByID(int id)
        {
            return _ticketRepository.GetTicketByID(id);
        }

        public Task<List<Ticket>> GetTicketsWithDetailsByAccountIdAsync(int? accountId)
        {
            return _ticketRepository.GetTicketsWithDetailsByAccountIdAsync(accountId);
        }

        public void UpdateTicket(Ticket ticket)
        {
            _ticketRepository.UpdateTicket(ticket);
        }
    }
}
