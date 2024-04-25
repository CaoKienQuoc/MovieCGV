using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.Seats
{
    public class DetailsModel : PageModel
    {
        private readonly ISeatService _seatService;

        public DetailsModel(ISeatService seatService)
        {
            _seatService = seatService;
        }

        public Seat Seat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1" || roleUser == "2")
            {
                if (id == null || _seatService.GetSeatList() == null)
                {
                    return NotFound();
                }

                var seat = _seatService.GetSeatById(id);
                if (seat == null)
                {
                    return NotFound();
                }
                else
                {
                    Seat = seat;
                }
                return Page();
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }
    }
}
