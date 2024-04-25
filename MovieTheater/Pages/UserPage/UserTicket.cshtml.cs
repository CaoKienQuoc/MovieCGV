using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.UserPage
{
    public class UserTicketModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;
        private readonly ISeatService _seatService;
        private readonly IFoodService _foodService;

        public UserTicketModel(ITicketService ticketService, IMovieService movieService, ISeatService seatService, IFoodService foodService)
        {
            _ticketService = ticketService;
            _movieService = movieService;
            _seatService = seatService;
            _foodService = foodService;
        }
        public IList<Seat> Seat { get; set; } = default!;
        public string Message { get; set; }
        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();
        public int AccountId { get; set; } = default!;
        public async Task OnGetAsync()
        {
            int accountId = int.Parse(HttpContext.Session.GetString("AccountId"));
            if (_movieService.GetAllMovies() != null || accountId != null)
            {
                var ticketList = await _ticketService.GetTicketsWithDetailsByAccountIdAsync(accountId);
                Tickets = ticketList.ToList();
                AccountId = accountId;
            }
        }

        public String GetSeatBySeatId(int seatId)
        {
            var movie = _seatService.GetSeatById(seatId);
            string seat = movie.SeatRow + movie.SeatColumn;
            return seat;
        }

        public String GetMovieNameByTicketId(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.MovieNameVn;
        }

        public String GetMovieYeauByTicketId(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.FromDate.ToString();
        }
        public String GetMovieStartTicketId(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.FromDate.ToString();
        }

        public String GetSmallImage(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.SmallImage.ToString();
        }


        public String GetMovieContent(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.Content;
        }
        public String GetMovieName(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.MovieNameEnglish;
        }
        public String GetMovieEndTicketId(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.ToDate.ToString();
        }
        public String GetRunTime(int mId)
        {
            var movie = _movieService.GetMoiveByID(mId);
            //_context.Movies.Where(m => m.MovieId.Equals(mId)).FirstOrDefault();
            return movie.Duration.ToString();
        }
        public String FoodPrice(int mId)
        {
            var movie = _foodService.GetFoodById(mId);
            return movie.Price.ToString();
        }

        public String FoodName(int mId)
        {
            var movie = _foodService.GetFoodById(mId);
            return movie.Name.ToString();
        }
    }
}