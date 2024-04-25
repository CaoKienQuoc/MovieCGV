using BusinessObject.Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieTheaterService.Interface;
using System.Text.RegularExpressions;

namespace MovieTheater.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;

        public RegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
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
        private bool IsValidImage(string image)
        {
            return !string.IsNullOrWhiteSpace(image) && !image.Contains(" ");
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
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
            // Kiểm tra và thêm lỗi nếu Image không hợp lệ
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
                    _accountService.Register(Account);
                    return RedirectToPage("./Index");
                }
            }
        }
    }
}