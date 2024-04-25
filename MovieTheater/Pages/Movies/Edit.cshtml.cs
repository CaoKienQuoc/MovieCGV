using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using MovieTheater.Models;
using System.Numerics;
using System.IO;
namespace MovieTheater.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IPhotoService _photoService;

        public EditModel(IMovieService movieService, IPhotoService photoService)
        {
            _movieService = movieService;
            _photoService = photoService;
        }

        [BindProperty]
        public EditMovieModels? Movie { get; set; } = default!;
        public string ErrorMessage { get; set; } = "";
        public long role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (id == null || _movieService.GetAllMovies() == null)
                {
                    return NotFound();
                }

                var movie = _movieService.GetMoiveByID((int)id);
            Movie = new EditMovieModels
            {
                MovieId = movie.MovieId,
                Actor = movie.Actor,
                CinemaRoomId = movie.CinemaRoomId,
                Content = movie.Content,
                Director = movie.Director,
                Duration = movie.Duration,
                FromDate = movie.FromDate,
                URL1 = movie.LargeImage,
                URL2 = movie.LargeImage,
                MovieNameEnglish = movie.MovieNameEnglish,
                MovieNameVn = movie.MovieNameVn,
                MovieProductionCompamy = movie.MovieProductionCompamy,
                Status = movie.Status,
                ToDate = movie.ToDate,
                Version = movie.Version,
            };
            if(movie == null)
            {
                return NotFound();
            }
            Movie = Movie;
            return Page();
            }
            else
            {
                TempData["ErrorMessage"] = "You must be an administrator to perform this action.";
                return Redirect("~/Home");
            }

        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (!Regex.IsMatch(Movie.MovieNameEnglish, @"^[a-zA-Z\s]+$"))
                {
                    TempData["message"] = "Movie name (English) must only contain letters and spaces.";
                    return Page();
                }

                if (!Regex.IsMatch(Movie.MovieNameVn, @"^[a-zA-Z\s]+$"))
                {
                    TempData["message"] = "Movie name (Vietnamese) must only contain letters and spaces.";
                    return Page();
                }

                var userMovies = await _movieService.GetMovieAsyncNoTracking(id);



                if (userMovies == null)
                {
                    return NotFound();
                }
                else
                {
                    var check = Movie.LargeImage;
                    var check1 = userMovies?.LargeImage;
                    var movies = new Movie();
                    if (Movie.LargeImage != null || Movie.SmallImage != null)
                    {
                        await _photoService.DeletePhotoAsync(userMovies.LargeImage);
                        await _photoService.DeletePhotoAsync(userMovies.SmallImage);
                        var result = await _photoService.AddPhotoAsync(Movie.LargeImage);
                        var result1 = await _photoService.AddPhotoAsync(Movie.SmallImage);
                        movies.MovieId = id;
                        movies.Actor = Movie.Actor;
                        movies.CinemaRoomId = Movie.CinemaRoomId;
                        movies.Content = Movie.Content;
                        movies.Director = Movie.Director;
                        movies.Duration = Movie.Duration;
                        movies.FromDate = Movie.FromDate;
                        movies.LargeImage = result.Url.ToString();
                        movies.MovieNameEnglish = Movie.MovieNameEnglish;
                        movies.MovieNameVn = Movie.MovieNameVn;
                        movies.MovieProductionCompamy = Movie.MovieProductionCompamy;
                        movies.SmallImage = result1.Url.ToString();
                        movies.Status = Movie.Status;
                        movies.ToDate = Movie.ToDate;
                        movies.Version = Movie.Version;
                    }
                    else
                    {
                        movies.MovieId = id;
                        movies.Actor = Movie.Actor;
                        movies.CinemaRoomId = Movie.CinemaRoomId;
                        movies.Content = Movie.Content;
                        movies.Director = Movie.Director;
                        movies.Duration = Movie.Duration;
                        movies.FromDate = Movie.FromDate;
                        movies.LargeImage = userMovies.LargeImage;
                        movies.MovieNameEnglish = Movie.MovieNameEnglish;
                        movies.MovieNameVn = Movie.MovieNameVn;
                        movies.MovieProductionCompamy = Movie.MovieProductionCompamy;
                        movies.SmallImage = userMovies.SmallImage;
                        movies.Status = Movie.Status;
                        movies.ToDate = Movie.ToDate;
                        movies.Version = Movie.Version;
                    }
                    _movieService.UpdateMovie(movies);
                    TempData["message"] = "Update Movie Succesfull!";                  
                    return RedirectToPage("./Index");
                }
                
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
            
        }
    }
}
