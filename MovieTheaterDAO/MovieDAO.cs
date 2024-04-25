using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterDAO
{
    public class MovieDAO
    {
        private readonly MovieTheaterCGVContext _dbContext;
        private static MovieDAO _instance;

        public MovieDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static MovieDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MovieDAO();
                }
                return _instance;
            }
        }
        public List<Movie> GetAllMovies()
        {
            try
            {
                return _dbContext.Movies.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting all movies.", ex);
            }
        }
        public Movie GetMoiveByID(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.MovieId.Equals(id));
        }
        public void AddMovieWithSeats(Movie movie)
        {
            try
            {
                
                _dbContext.Add(movie);
                _dbContext.SaveChanges();

                
                char[] seatColumns = { 'A', 'B', 'C', 'D', 'E', 'F', }; 

                for (int row = 1; row <= 8; row++) 
                {
                    for (int col = 0; col < 6; col++) 
                    {
                        Seat seat = new Seat
                        {
                            SeatColumn = seatColumns[col].ToString(), 
                            SeatRow = row, 
                            SeatStatus = 0, 
                            SeatType = movie.MovieId 
                        };

                        _dbContext.Add(seat);
                    }
                }

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding movie with seats.", ex);
            }
        }


        public void UpdateMovie(Movie movie)
        {
            Movie mov = GetMoiveByID(movie.MovieId);
            if (mov != null)
            {
                mov.Actor = movie.Actor;
                mov.CinemaRoomId = movie.CinemaRoomId;
                mov.Content = movie.Content;
                mov.Director = movie.Director;
                mov.Duration = movie.Duration;
                mov.FromDate = movie.FromDate;
                mov.LargeImage = movie.LargeImage;
                mov.MovieNameEnglish = movie.MovieNameEnglish;
                mov.MovieNameVn = movie.MovieNameVn;
                mov.MovieProductionCompamy = movie.MovieProductionCompamy;
                mov.SmallImage = movie.SmallImage;
                mov.Status = movie.Status;
                mov.ToDate = movie.ToDate;
                mov.Version = movie.Version;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteMovie(Movie movie)
        {
            Movie mov = GetMoiveByID(movie.MovieId);
            if (mov != null)
            {
                _dbContext.Remove(mov);
                _dbContext.SaveChanges();
            }
        }
        public async Task<Movie> GetMovieAsyncNoTracking(int id)
        {
            return await _dbContext.Movies.AsNoTracking().FirstOrDefaultAsync(i => i.MovieId == id);
        }
    }
}
