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
    public class SeatRepository : ISeatRepository
    {
        public void AddSeat(int? seatId) =>SeatDAO.Instance.AddSeat(seatId);

        public void DeleteSeat(Seat seat)=>SeatDAO.Instance.DeleteSeat(seat);

        public Seat GetSeatById(int? id)=>SeatDAO.Instance.GetSeatById(id);

        public List<Seat> GetSeatBySeatType(int? id) => SeatDAO.Instance.GetSeatBySeatType(id);

        public List<Seat> GetSeatList()=>SeatDAO.Instance.GetSeatList();

        public void UpdateSeat(int? seatId) =>SeatDAO.Instance.UpdateSeat(seatId);
    }
}
