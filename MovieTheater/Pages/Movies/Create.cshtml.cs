using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using MovieTheater.Models;
using BusinessObject;
using System.IO;

namespace MovieTheater.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IPhotoService _photoService;

        public CreateModel(IMovieService movieService, IPhotoService photoService)
        {
            _movieService = movieService;
            _photoService = photoService;
        }

        public string ErrorMessage { get; set; } = "";
        public long role { get; set; }
        public IActionResult OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                return Page();
            }
            else
            {
                TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                return Redirect("~/Home");
            }
            //return Page();
        }

        [BindProperty]
        public MovieModels Movie { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "1")
            {
                TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                return Redirect("~/Home");
            }
            else
            {
                if (!Regex.IsMatch(Movie.MovieNameEnglish, @"^[a-zA-Z\s]+$"))
                {
                    TempData["ErrorMessage"] = "Movie name (English) must only contain letters and spaces.";
                    return Page();
                }

                if (!Regex.IsMatch(Movie.MovieNameVn, @"^[a-zA-Z\s]+$"))
                {
                    TempData["ErrorMessage"] = "Movie name (Vietnamese) must only contain letters and spaces.";
                    return Page();
                }

                var result = await _photoService.AddPhotoAsync(Movie.LargeImage);
                var result1 = await _photoService.AddPhotoAsync(Movie.SmallImage);

                var movie = new Movie
                {
                    Actor = Movie.Actor,
                    CinemaRoomId = Movie.CinemaRoomId,
                    Content = Movie.Content,
                    Director = Movie.Director,
                    Duration = Movie.Duration,
                    FromDate = Movie.FromDate,
                    LargeImage = result.Url.ToString(),
                    MovieNameEnglish = Movie.MovieNameEnglish,
                    MovieNameVn = Movie.MovieNameVn,
                    MovieProductionCompamy = Movie.MovieProductionCompamy,
                    SmallImage = result1.Url.ToString(),
                    Status = Movie.Status,
                    ToDate = Movie.ToDate,
                    Version = Movie.Version,
                };
                _movieService.AddMovieWithSeats(movie);
                return RedirectToPage("./Index");
            }
        }
    }
}
