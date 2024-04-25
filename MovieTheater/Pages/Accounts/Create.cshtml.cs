using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;
using System.Text.RegularExpressions;

namespace MovieTheater.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1")
            {
                return Page();
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
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
        private bool IsValidImage(string image)
        {
            return !string.IsNullOrWhiteSpace(image) && !image.Contains(" ");
        }
        private bool IsValidIdentityCard(string identityCard)
        {
            return identityCard.All(char.IsDigit);
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var roleUser = HttpContext.Session.GetString("UserRole");
            if (roleUser == "1")
            {
                if (!ModelState.IsValid || _accountService.GetAllAccount == null || Account == null)
                {
                    return Page();
                }
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
                if (!IsValidImage(Account.Image))
                {
                    ModelState.AddModelError("Account.Image", "Image must not contain spaces.");
                    return Page();
                }

                bool email = _accountService.IsEmailExist(Account);
                if (email == true)
                {
                    ModelState.AddModelError("Account.Email", "Email is exist!");
                    return Page();
                }
                else
                {
                    bool username = _accountService.IsUsernameExist(Account);
                    if (username == true)
                    {
                        ModelState.AddModelError("Account.Username", "Username is exist!");
                        return Page();
                    }
                    else
                    {
                        _accountService.AddAccount(Account);
                        return RedirectToPage("./Index");
                    }
                }
            }
            else
            {
                TempData["message"] = "You Are Not Admin!.";
                return Redirect("~/Home");
            }

        }
    }
}