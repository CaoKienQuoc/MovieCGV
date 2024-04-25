using BusinessObject.Datalayer;
using MovieTheaterDAO;
using MovieTheaterRepo;
using MovieTheaterRepo.Implement;
using MovieTheaterRepo.Interface;
using MovieTheaterService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Implement
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService()
        {
            movieRepository = new MovieRepository();
        }

        public void AddMovieWithSeats(Movie movie) => movieRepository.AddMovieWithSeats(movie);
        public void DeleteMovie(Movie movie) => movieRepository.DeleteMovie(movie);
        public List<Movie> GetAllMovies() => movieRepository.GetAllMovies();
        public Movie GetMoiveByID(int id) => movieRepository.GetMoiveByID(id);

        public Task<Movie> GetMovieAsyncNoTracking(int id) => movieRepository.GetMovieAsyncNoTracking(id);
        

        public void UpdateMovie(Movie movie) => movieRepository.UpdateMovie(movie);
    }
}
