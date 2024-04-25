using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using Newtonsoft.Json;

namespace MovieTheater.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _movieService;

        public IndexModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IList<Movie> Movie { get; set; } = default!;
        public string ErrorMessage { get; set; } = "";
        public long role { get; set; }

        public async Task OnGetAsync()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                Movie = _movieService.GetAllMovies();
            }
            else
            {
                TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                Redirect("~/Home");
            }
        }
    }
}
