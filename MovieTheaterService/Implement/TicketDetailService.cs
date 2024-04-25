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
    public class TicketDetailService : ITicketDetailService
    {
        private readonly ITicketDetailRepository _ticketDetailRepository;

        public TicketDetailService(ITicketDetailRepository ticketDetailRepository)
        {
            _ticketDetailRepository = ticketDetailRepository;
        }

        public void AddTicketDetail(TicketDetail ticketDetail)
        {
            _ticketDetailRepository.AddTicketDetail(ticketDetail);
        }

        public List<TicketDetail> GetAllTick(int ticketDetailsId)
        {
            return _ticketDetailRepository.GetAllTick(ticketDetailsId);
        }

        public TicketDetail GetDetailTicketByDetailID(int? id)
        {
            return _ticketDetailRepository.GetDetailTicketByDetailID(id);
        }

        public TicketDetail GetTicketDetailByTicketId(int? ticketId)
        {
            return _ticketDetailRepository.GetTicketDetailByTicketId(ticketId);
        }

        public decimal UpdateTicketDetail(TicketDetail ticketDetail, int? ticketId)
        {
            return _ticketDetailRepository.UpdateTicketDetail(ticketDetail, ticketId);
        }
    }
}
