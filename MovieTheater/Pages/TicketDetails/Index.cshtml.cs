using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using MovieTheaterService.Implement;

namespace MovieTheater.Pages.TicketDetails
{
    public class IndexModel : PageModel
    {
        private readonly ITicketDetailService _ticketDetailService;

        public IndexModel(ITicketDetailService ticketDetailService)
        {
            _ticketDetailService = ticketDetailService;
        }

        public IList<TicketDetail> TicketDetail { get;set; } = new List<TicketDetail>();    

        public async Task OnGetAsync()
        {
            var ticketDetail = new TicketDetail();
            var ticketDetailId = ticketDetail.TicketDetailsId;
            if (_ticketDetailService.GetAllTick(ticketDetailId) != null)
            {
                _ticketDetailService.GetAllTick(ticketDetailId);
                }
        }
    }
}
