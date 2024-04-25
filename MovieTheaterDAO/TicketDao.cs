using System;
using MovieTheaterDAO;
using BusinessObject.Datalayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieTheaterDAO
{
    public class TicketDAO
    {
        private readonly MovieTheaterCGVContext _dbContext;
        private static TicketDAO _instance;

        public TicketDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static TicketDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketDAO();
                }
                return _instance;
            }
        }
        public Task<List<Ticket>> GetTicketsWithDetailsByAccountIdAsync(int? accountId)
        {
            return _dbContext .Tickets
                .Include(t => t.TicketDetails)
                    .ThenInclude(td => td.Seat)
                .Where(m => m.AccountId == accountId)
                .ToListAsync();
        }
        public List<Ticket> GetAllTicketByUserId(int? accountId)
        {
            return _dbContext.Tickets.Where(t => t.AccountId.Equals(accountId)).ToList();
        }
        public Ticket GetTicketByID(int id)
        {
            return _dbContext.Tickets.Include(m => m.TicketDetails).FirstOrDefault(m => m.TicketId.Equals(id));
        }
        public bool AddTicket(Ticket ticket, TicketDetail ticketDetails)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Validate ticket and ticket details
                    if (!ValidateTicket(ticket, ticketDetails))
                        return false;

                    // Add ticket to database
                    _dbContext.Tickets.Add(ticket);
                    _dbContext.SaveChanges();

/*                    // Set ticket ID for the ticket detail
                    ticketDetails.TicketDetailsId = ticket.TicketId;

                    // Add ticket detail to database
                    _dbContext.TicketDetails.Add(ticketDetails);
                    _dbContext.SaveChanges();*/

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Log the exception or handle it accordingly
                    Console.WriteLine($"Error occurred while adding ticket: {ex.Message}");
                    return false;
                }
            }
        }


        private bool ValidateTicket(Ticket ticket, TicketDetail ticketDetail)
        {
            // Check if ticket and ticket detail are provided
            if (ticket == null || ticketDetail == null)
            {
                Console.WriteLine("Ticket and ticket detail are required.");
                return false;
            }

            // Check if selected seat is available
            var seat = _dbContext.Seats.FirstOrDefault(s => s.SeatId == ticketDetail.SeatId);
            if (seat == null || seat.SeatStatus == 1)
            {
                Console.WriteLine($"Seat {ticketDetail.SeatId} is not available.");
                return false;
            }

            // Additional validation rules can be added here

            return true;
        }


        public void UpdateTicket(Ticket ticket)
        {
            Ticket existingTicket = _dbContext.Tickets
                .Include(t => t.TicketDetails)
                .SingleOrDefault(t => t.TicketId == ticket.TicketId);

            if (existingTicket != null)
            {
                // Update ticket properties
                existingTicket.AccountId = ticket.AccountId; // Update other properties as needed

                // Find the specific ticket detail to update
                var ticketDetailToUpdate = existingTicket.TicketDetails.TicketDetailsId.Equals(ticket.TicketDetailsId);

                if (ticketDetailToUpdate != null)
                {
                    // Update seat and food for ticket detail
                    double priceChange = decimal.ToDouble(TicketDetailDAO.Instance.UpdateTicketDetail(ticket.TicketDetails, ticket.TicketDetailsId)); 
                    // Update price when food change
                    existingTicket.Price = priceChange;

                }
                else
                {
                    // Handle if ticket detail does not exist
                }

                _dbContext.SaveChanges();
            }


        }
    }
}
