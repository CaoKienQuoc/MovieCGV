using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace MovieTheater.Pages
{
    public class AdminPageModel : PageModel
    {



        public IActionResult OnGet()
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1")
            {
                return Page();
            }
            else
            {
                TempData["message"] = "You must be login admin to do this function!.";
                return Redirect("/Login");
            }
        }

        public IActionResult OnPostAsync()
        {
            return Redirect("~/Home");
        }

        public IActionResult OnPostLogout()
        {
            // Xóa dữ liệu session
            HttpContext.Session.Clear();

            // Chuyển hướng đến trang /Login
            return Redirect("/Login");
        }

    }
}