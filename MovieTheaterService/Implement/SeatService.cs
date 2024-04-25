using BusinessObject.Datalayer;
using MovieTheaterRepo.Interface;
using MovieTheaterService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Implement
{
    public class SeatService : ISeatService
    {
        private ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public void AddSeat(int? seatId)
        {
            _seatRepository.AddSeat(seatId);
        }

        public void DeleteSeat(Seat seat)
        {
            _seatRepository.DeleteSeat(seat);
        }

        public Seat GetSeatById(int? id)
        {
            return _seatRepository.GetSeatById(id);
        }

        public List<Seat> GetSeatBySeatType(int? id)
        {
            return _seatRepository.GetSeatBySeatType(id);
        }

        public List<Seat> GetSeatList()
        {
            return _seatRepository.GetSeatList();
        }

        public void UpdateSeat(int? seatId)
        {
            _seatRepository.UpdateSeat(seatId);
        }
    }
}
