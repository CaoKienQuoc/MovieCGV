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
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DeleteModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (id == null || _accountService.GetAllAccount == null)
            {
                return NotFound();
            }

            var account = _accountService.GetAccountByID(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (id == null || _accountService.GetAllAccount == null)
                {
                    return NotFound();
                }
                var account = _accountService.GetAccountByID(id);

                if (account != null)
                {
                    Account = account;
                    _accountService.DeleteAccount(account);
                }

                return RedirectToPage("./Index");

            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }
    }
}