using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Interface
{
    public interface IMovieRepository
    {
        public List<Movie> GetAllMovies();
        public Movie GetMoiveByID(int id);
        public void AddMovieWithSeats(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(Movie movie);
        public Task<Movie> GetMovieAsyncNoTracking(int id);

    }
}
