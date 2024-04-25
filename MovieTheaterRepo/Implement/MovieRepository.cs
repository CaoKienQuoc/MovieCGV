using BusinessObject.Datalayer;
using MovieTheaterDAO;
using MovieTheaterRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Implement
{
    public class MovieRepository : IMovieRepository
    {
        public void AddMovieWithSeats(Movie movie) => MovieDAO.Instance.AddMovieWithSeats(movie);
        public void DeleteMovie(Movie movie) => MovieDAO.Instance.DeleteMovie(movie);
        public List<Movie> GetAllMovies() => MovieDAO.Instance.GetAllMovies();
        public Movie GetMoiveByID(int id) => MovieDAO.Instance.GetMoiveByID(id);

        public Task<Movie> GetMovieAsyncNoTracking(int id) => MovieDAO.Instance.GetMovieAsyncNoTracking(id);
        
        public void UpdateMovie(Movie movie) => MovieDAO.Instance.UpdateMovie(movie);
    }
}
