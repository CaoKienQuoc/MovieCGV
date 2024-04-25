using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterDAO
{
    public class SeatDAO
    {
        private static SeatDAO _instance = null;
        private static MovieTheaterCGVContext _dbContext = null;
        public SeatDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static SeatDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SeatDAO();
                }
                return _instance;
            }
        }

        public List<Seat> GetSeatList()
        {
            try
            {
                return _dbContext.Seats.ToList();
            }catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Seat GetSeatById(int? id)
        {
            try
            {
                return _dbContext.Seats.FirstOrDefault(s => s.SeatId == id);
            }catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public List<Seat> GetSeatBySeatType(int? id)
        {
            try
            {
                return _dbContext.Seats.Where(s => s.SeatType == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void AddSeat(int? seatId) 
        {
            try
            {
                Seat seat1 = GetSeatById(seatId);
                if (seat1 != null)
                {
                    // Đặt trạng thái của chỗ ngồi thành 1
                    seat1.SeatStatus = 1;

                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void UpdateSeat(int? seatId)
        {
            try
            {
                Seat seat1 = GetSeatById(seatId);
                if (seat1 != null)
                {
                    // Đặt trạng thái của chỗ ngồi thành 1
                    seat1.SeatStatus = 0;

                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void DeleteSeat(Seat seat)
        {
            try
            {
                Seat seat1 = GetSeatById(seat.SeatId);
                if (seat1 != null)
                {
                    _dbContext.Remove(seat);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
