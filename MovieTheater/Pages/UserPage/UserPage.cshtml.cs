using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;


namespace MovieTheater.Pages.UserPage

{
    public class HomePageModel : PageModel
    {
        private readonly IMovieService _movieService;

        public HomePageModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IList<Seat> Seat { get; set; } = default!;
        public int AccountId { get; set; } = default!;
        public string Message { get; set; }
        public IList<Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_movieService.GetAllMovies() != null)
            {
                Movie = _movieService.GetAllMovies();
            }

            var accountIdString = HttpContext.Session.GetString("AccountId");
            if (!string.IsNullOrEmpty(accountIdString))
            {
                AccountId = int.Parse(accountIdString);
            }
            else
            {
                // Handle the case when AccountId is not found in the session
            }
        }
    }
}
