using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private ITicketService _ticketService;
        private IAccountService _accountService;

        public IndexModel(ITicketService ticketService, IAccountService accountService)
        {
            _ticketService = ticketService;
            _accountService = accountService;
        }

        public IList<Ticket> Ticket { get;set; } = new List<Ticket>();

        public async Task OnGetAsync()
        {
            var ticket = new Ticket();
            var accountId = ticket.AccountId;
            if (_ticketService.GetAllTicketByUserId(accountId) != null)
            {
                _ticketService.GetAllTicketByUserId(accountId);
            }
        }
    }
}
