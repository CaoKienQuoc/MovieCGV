using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;

namespace MovieTheaterDAO
{
    public class TicketDetailDAO
    {
        private readonly MovieTheaterCGVContext _dbContext;
        private static TicketDetailDAO _instance;

        public TicketDetailDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static TicketDetailDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketDetailDAO();
                }
                return _instance;
            }
        }
        public List<TicketDetail> GetAllTick(int? ticketDetailsId)
        {
            return _dbContext.TicketDetails.Where(t => t.TicketDetailsId.Equals(ticketDetailsId)).Include(t => t.Food).Include(t => t.Seat).ToList();
        }

        public TicketDetail GetDetailTicketByDetailID(int? id)
        {
            return _dbContext.TicketDetails.Include(m => m.Food).Include(m => m.SeatId).FirstOrDefault(m => m.TicketDetailsId.Equals(id));
        }
        
       
        public decimal UpdateTicketDetail(TicketDetail ticketDetail, int? ticketId)
        {
            TicketDetail existingTicketDetail = GetTicketDetailByTicketId(ticketId);


            decimal updatePrice= 0;
            if (existingTicketDetail != null)
            {
                // Update ticket detail properties
                existingTicketDetail.SeatId = ticketDetail.SeatId;
                existingTicketDetail.FoodId = ticketDetail.FoodId;
                existingTicketDetail.MovieId = ticketDetail.MovieId;

                // Check if movie or seat has changed
                bool movieChanged = existingTicketDetail.MovieId != ticketDetail.MovieId;
                bool seatChanged = existingTicketDetail.SeatId != ticketDetail.SeatId;

                // Recalculate price if movie or seat has changed
                if (movieChanged || seatChanged)
                {
                    updatePrice = CalculateTicketPrice(ticketDetail.FoodId);
                }

                _dbContext.SaveChanges();
            }
            return updatePrice;
        }

        private decimal CalculateTicketPrice(int? foodId)
        {
            // Assuming you have the logic to calculate ticket price based on the food
            decimal foodPrice = _dbContext.Foods.FirstOrDefault(f => f.FoodId == foodId)?.Price ?? 0;

            // You can add more complex logic here if needed

            return foodPrice;
        }

 

        public TicketDetail GetTicketDetailByTicketId(int? ticketId)
        {
            try
            {
                var ticketDetail = _dbContext.Tickets
                    .Include(t => t.TicketDetails)
                    .ThenInclude(td => td.Movie)
                    .Include(t => t.TicketDetails)
                    .ThenInclude(td => td.Seat)
                    .Include(t => t.TicketDetails)
                    .ThenInclude(td => td.Food)
                    .SingleOrDefault(t => t.TicketId == ticketId)?
                    .TicketDetails;

                return ticketDetail;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"Error occurred while getting ticket details: {ex.Message}");
                return null;
            }
        }

        public void AddTicketDetail(TicketDetail ticketDetail)
        {
            try
            {
                _dbContext.Add(ticketDetail);
                _dbContext.SaveChanges();
            }
            catch  (Exception ex)
            {
                throw new Exception();
            }
        }
    }

}

