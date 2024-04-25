using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;

namespace MovieTheater.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieService _movieService;

        public DetailsModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1")
            {
                if (id == null || _movieService.GetAllMovies() == null)
                {
                    return NotFound();
                }
                var movie = _movieService.GetMoiveByID(id);

                if (movie == null)
                {
                    return NotFound();
                }
                else
                {
                    Movie = movie;
                }
                return Page();
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }
    }
}
