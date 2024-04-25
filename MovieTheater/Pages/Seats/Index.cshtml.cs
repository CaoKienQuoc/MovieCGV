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
    public class IndexModel : PageModel
    {
        private readonly ISeatService seatService;

        public IndexModel(ISeatService _seatService)
        {
            seatService = _seatService;
        }

        public IList<Seat> Seat { get; set; }

        public async Task OnGetAsync()
        {
            if (seatService.GetSeatList() != null)
            {
                Seat = seatService.GetSeatList();
            }

        }

        public IActionResult OnPostReset(int? seatId)
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1" || roleUser == "2")
            {
                // Kiểm tra xem seatService có được khởi tạo không trước khi sử dụng
                if (seatService != null)
                {
                    seatService.UpdateSeat(seatId);
                    return RedirectToPage("/Seats/Index"); // Hoặc trang khác tùy theo nhu cầu của bạn
                }
                else
                {
                    // Xử lý trường hợp seatService không được khởi tạo
                    TempData["message"] = "An error occurred while choosing the seat. Please try again later.";
                    return RedirectToPage("/Seats/Index"); // Hoặc trang khác tùy theo nhu cầu của bạn
                }
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }
        public IActionResult OnPostChooseSeat(int? seatId)
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1" || roleUser == "2")
            {
                // Kiểm tra xem seatService có được khởi tạo không trước khi sử dụng
                if (seatService != null)
                {
                    seatService.AddSeat(seatId);
                    return RedirectToPage("/Seats/Index"); // Hoặc trang khác tùy theo nhu cầu của bạn
                }
                else
                {
                    // Xử lý trường hợp seatService không được khởi tạo
                    TempData["message"] = "An error occurred while choosing the seat. Please try again later.";
                    return RedirectToPage("/Seats/Index"); // Hoặc trang khác tùy theo nhu cầu của bạn
                }
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }
    }
}