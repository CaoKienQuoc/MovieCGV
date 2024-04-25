using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Interface
{
    public interface ISeatRepository
    {
        public List<Seat> GetSeatList();

        public Seat GetSeatById(int? id);

        public void AddSeat(int? seatId);

        public void UpdateSeat(int? seatId);

        public void DeleteSeat(Seat seat);
        public List<Seat> GetSeatBySeatType(int? id);
    }
}
