using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieTheater.Pages
{
    public class LogoutModel : PageModel
    {

        public LogoutModel()
        {
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Xóa dữ liệu session
            HttpContext.Session.Clear();

            // Chuyển hướng đến trang /Login
            return Redirect("/Login");
        }
    }
}
