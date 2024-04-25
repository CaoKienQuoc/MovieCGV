using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILoginService _accountService;

        public LoginModel(ILoginService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }  

        public IActionResult OnPost()
        {
            var account = _accountService.GetAccountByEmail(Email);

            if (account != null && account.Password.Equals(Password))
            {
                HttpContext.Session.SetString("UserRole", account.RoleId.ToString());
                HttpContext.Session.SetString("AccountId", account.AccountId.ToString());
                if (account.RoleId == 1)

                {
                    return RedirectToPage("AdminPage");
                }
                if (account.RoleId == 2)
                {
                    //return RedirectToPage("UserPage/Home", new { id = account.AccountId });
                    return Redirect("~/Home");
                }

                else
                {
                    TempData["message"] = "Have Error When Login!";
                    return Page();
                }
            }
            else
            {
                TempData["message"] = "Email or Password invalid!";
                return Page();
            }
        }
    }
}
