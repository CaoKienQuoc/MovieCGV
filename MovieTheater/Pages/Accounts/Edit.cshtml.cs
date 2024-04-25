using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using Microsoft.CodeAnalysis.Differencing;
using System.Text.RegularExpressions;

namespace MovieTheater.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;

        public EditModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        private bool IsValidFullName(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName) && Regex.IsMatch(fullName.Trim(), @"^[a-zA-Z]+(?:\s+[a-zA-Z]+)*$");
        }


        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
        }


        private bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username) && !username.Any(char.IsWhiteSpace) && Regex.IsMatch(username, @"^[a-zA-Z0-9_]*$");
        }

        private bool IsValidIdentityCard(string identityCard)
        {
            return identityCard.All(char.IsDigit);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
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
            Account = account;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                // Kiểm tra và thêm lỗi nếu FullName không hợp lệ
                if (!IsValidFullName(Account.FullName))
                {
                    ModelState.AddModelError("Account.FullName", "Full name must contain only letters and spaces (no leading or trailing spaces).");
                    return Page();
                }

                // Kiểm tra và thêm lỗi nếu PhoneNumber không hợp lệ
                if (!IsValidPhoneNumber(Account.PhoneNumber))
                {
                    ModelState.AddModelError("Account.PhoneNumber", "Phone number must contain only digits.");
                    return Page();
                }

                // Kiểm tra và thêm lỗi nếu Username không hợp lệ
                if (!IsValidUsername(Account.Username))
                {
                    ModelState.AddModelError("Account.Username", "Username must contain only letters, numbers, and underscores.");
                    return Page();
                }
                if (!IsValidIdentityCard(Account.IdentityCard))
                {
                    ModelState.AddModelError("Account.IdentityCard", "Identity card must contain only numbers.");
                    return Page();
                }
                var existingAccount = _accountService.GetAccountByID(Account.AccountId);
                bool email = _accountService.IsEmailExist(Account);
                if (Account.Email != existingAccount.Email && email == true)
                {
                    ModelState.AddModelError("Account.Email", "Email is exist!");
                    return Page();
                }
                else
                {
                    bool username = _accountService.IsUsernameExist(Account);
                    if (Account.Username != existingAccount.Username && username == true)
                    {
                        ModelState.AddModelError("Account.Username", "Username is exist!");
                        return Page();
                    }
                    else
                    {
                        _accountService.UpdateAccount(Account);
                        return RedirectToPage("./Index");
                    }
                }

            }

        }


    }
}