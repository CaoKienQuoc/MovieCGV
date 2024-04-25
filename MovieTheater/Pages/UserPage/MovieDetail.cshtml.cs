using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.UserPage
{
    public class MovieDetailModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly ISeatService _seatService;
        private readonly IFoodService _foodService;
        private readonly IAccountService _accountService;
        private readonly ITicketService _ticketService;
        private readonly ITicketDetailService _ticketDetailService;
        public MovieDetailModel(IMovieService movieService, ISeatService seatService, IFoodService foodService, IAccountService accountService, ITicketService ticketService, ITicketDetailService ticketDetailService)
        {
            _movieService = movieService;
            _seatService = seatService;
            _foodService = foodService;
            _accountService = accountService;
            _ticketService = ticketService;
            _ticketDetailService = ticketDetailService;
        }

        public Movie Movie { get; set; } = default!;
        public string Message { get; set; }

        public int AccountId { get; set; } = default!;

        public IList<Seat> Seat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!Request.Query.ContainsKey("movieId"))
            {
                // Log or handle the case where movieId is not present in the query string
                // For now, returning NotFound()
                return NotFound();
            }
            if (!int.TryParse(Request.Query["movieId"], out int id))
            {
                // Log or handle the case where movieId is not a valid integer
                // For now, returning NotFound()
                return NotFound();
            }
            var accountIdString = HttpContext.Session.GetString("AccountId");
            if (!string.IsNullOrEmpty(accountIdString))
            {
                AccountId = int.Parse(accountIdString);
            }

            var movie = _movieService.GetMoiveByID(id);

            var seat = _seatService.GetSeatBySeatType(id);

            if (movie == null)
            {
                // Log or handle the case where movie is null
                // For now, returning NotFound()
                return NotFound();
            }

            // If movie is found, assign it to the Movie property
            Movie = movie;
            Seat = seat;

            return Page();
        }
        public Seat GetSeatByRowAnddCoulm(string column, int row)
        {
            return Seat.FirstOrDefault(s => s.SeatRow == row && s.SeatColumn == column);
        }



        public async Task<IActionResult> OnGetConfirmPurchase(string seatId, string foodIndex, string uid, string movieId)
        {
            var accountId = HttpContext.Session.GetString("AccountId");
            var movie = _movieService.GetMoiveByID(int.Parse(movieId));

            var seat = _seatService.GetSeatById(int.Parse(seatId));
            var food = _foodService.GetFoodById(int.Parse(foodIndex));
            var account = _accountService.GetAccountByID(int.Parse(uid)); 
            if (seat != null || food != null || account != null)
            {
                // Your purchase confirmation logic here
                TicketDetail ticketDetail = new TicketDetail
                {
                    SeatId = int.Parse(seatId),
                    FoodId = int.Parse(foodIndex),
                    MovieId = int.Parse(movieId),
                };

                _ticketDetailService.AddTicketDetail(ticketDetail);

                if(ticketDetail!=null)
                {
                    Ticket ticket = new Ticket
                    {
                        Price = 10.0 + decimal.ToDouble((decimal)food.Price), // example price
                        TicketType = 1, // example ticket type
                        AccountId = int.Parse(accountId), // example account ID
                        TicketDetailsId = ticketDetail.TicketDetailsId // using the ID of the created TicketDetail
                    };
                    _ticketService.AddTicket(ticket, ticketDetail);

                    seat.SeatStatus = 1; // Update seat status to 0
                    _seatService.AddSeat(seat.SeatId);

                    Message = "Purchase confirmed for seat ID: " + seatId;
                    return new JsonResult(new { message = Message });
                }
            }
            else
            {
                return new JsonResult(new { error = "Seat not found" }) { StatusCode = 404 };
            }


            return Page();
        }

    }
}