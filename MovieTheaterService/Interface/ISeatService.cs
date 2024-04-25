using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Interface
{
    public interface ISeatService
    {
        public List<Seat> GetSeatList();

        public Seat GetSeatById(int? id);

        public void AddSeat(int? seatId);

        public void UpdateSeat(int? seatId);

        public void DeleteSeat(Seat seat);
        public List<Seat> GetSeatBySeatType(int? id);
    }
}
