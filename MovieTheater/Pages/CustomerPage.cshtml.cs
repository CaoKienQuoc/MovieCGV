using BusinessObject.Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieTheaterService.Interface;
using System.Text.RegularExpressions;

namespace MovieTheater.Pages
{
    public class CustomerPageModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CustomerPageModel(IAccountService accountService)
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
            /*Account account = _accountService.GetAccountByID(id);

            if (Account.AccountId == null) Account.AccountId = account.AccountId;
            if (Account.Address == null) Account.Address = account.Address;
            if (Account.DateOfBirth == null) Account.DateOfBirth = account.DateOfBirth;
            if (Account.Email == null) Account.Email = account.Email;
            if (Account.FullName == null) Account.FullName = account.FullName;
            if (Account.Gender == null) Account.Gender = account.Gender;
            if (Account.IdentityCard == null) Account.IdentityCard = account.IdentityCard;
            if (Account.Image == null) Account.Image = account.Image;
            if (Account.Password == null) Account.Password = account.Password;
            if (Account.PhoneNumber == null) Account.PhoneNumber = account.PhoneNumber;
            if (Account.Status == null) Account.Status = account.Status;
            if (Account.Username == null) Account.Username = account.Username;

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
            else
            {
                _accountService.UpdateAccount(Account);
                return Redirect("~/Home");
            }*/


            Account account = _accountService.GetAccountByID(id);

            if (Account.AccountId == null) Account.AccountId = account.AccountId;
            if (Account.Address == null) Account.Address = account.Address;
            if (Account.DateOfBirth == null) Account.DateOfBirth = account.DateOfBirth;
            if (Account.Email == null) Account.Email = account.Email;
            if (Account.FullName == null) Account.FullName = account.FullName;
            if (Account.Gender == null) Account.Gender = account.Gender;
            if (Account.IdentityCard == null) Account.IdentityCard = account.IdentityCard;
            if (Account.Image == null) Account.Image = account.Image;
            if (Account.Password == null) Account.Password = account.Password;
            if (Account.PhoneNumber == null) Account.PhoneNumber = account.PhoneNumber;
            if (Account.Status == null) Account.Status = account.Status;
            if (Account.Username == null) Account.Username = account.Username;

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
            int roleId = int.Parse(HttpContext.Session.GetString("UserRole"));
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
                    Account.RoleId = roleId;
                    _accountService.UpdateAccount(Account);
                    return Redirect("~/Home");
                }
            }


        }
    }
}
