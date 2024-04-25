using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;

namespace MovieTheater.Pages.TicketDetails
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.Datalayer.MovieTheaterCGVContext _context;

        public DetailsModel(BusinessObject.Datalayer.MovieTheaterCGVContext context)
        {
            _context = context;
        }

      public TicketDetail TicketDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TicketDetails == null)
            {
                return NotFound();
            }

            var ticketdetail = await _context.TicketDetails.FirstOrDefaultAsync(m => m.TicketDetailsId == id);
            if (ticketdetail == null)
            {
                return NotFound();
            }
            else 
            {
                TicketDetail = ticketdetail;
            }
            return Page();
        }
    }
}
