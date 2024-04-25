using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;

namespace MovieTheater.Pages.Shared
{
    public class _UserLayoutModel : PageModel
    {
        private readonly MovieTheaterCGVContext _context;

        public _UserLayoutModel(MovieTheaterCGVContext context)
        {
            _context = context;
        }
        public IList<Seat> Seat { get; set; } = default!;
        public string Message { get; set; }

        public int AccountId { get;  set; } = default!;
        public void OnGet()
        {
            var accountIdString = HttpContext.Session.GetString("AccountId");
            if (!string.IsNullOrEmpty(accountIdString))
            {
                AccountId = int.Parse(accountIdString);
            }
            else
            {
                // Handle the case when AccountId is not found in the session
            }

        }
        public Seat GetSeatByRowAnddCoulm(string column, int row)
        {
            return Seat.FirstOrDefault(s => s.SeatRow == row && s.SeatColumn ==  column);
        }

        public IActionResult OnGetConfirmPurchase(string seatId, string foodIndex)
        {
            var seat = _context.Seats.FirstOrDefault(s => s.SeatId == int.Parse(seatId));

            if (seat != null)
            {
                // Your purchase confirmation logic here
                Message = "Purchase confirmed for seat ID: " + seatId;
                return new JsonResult(new { message = Message });
            }
            else
            {
                return new JsonResult(new { error = "Seat not found" }) { StatusCode = 404 };
            }


            return Page();
        }
    }
}
