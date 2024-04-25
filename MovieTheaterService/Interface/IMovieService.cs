using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Interface
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        public Movie GetMoiveByID(int id);
        public void AddMovieWithSeats(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(Movie movie);
        public Task<Movie> GetMovieAsyncNoTracking(int id);
    }
}
