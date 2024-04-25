using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Account { get; set; } = default!;

        public IActionResult OnGetAsync()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (_accountService.GetAllAccount != null)
                {
                    Account = _accountService.GetAllAccount();
                }
                return Page();
            }
            else
            {
                TempData["message"] = "You Are Not Admin!.";
                return Redirect("~/Home");
            }
        }
    }
}