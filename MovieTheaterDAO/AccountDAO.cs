using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterDAO
{
    public class AccountDAO
    {
        private readonly MovieTheaterCGVContext _dbContext;
        private static AccountDAO _instance;

        public AccountDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static AccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAO();
                }
                return _instance;
            }
        }
        public List<Account> GetAllAccount()
        {
            return _dbContext.Accounts.ToList();
        }
        public Account GetAccountByID(int? id)
        {
            return _dbContext.Accounts.FirstOrDefault(m => m.AccountId.Equals(id));
        }
        public void AddAccount(Account account)
        {
            Account user = GetAccountByID(account.AccountId);
            if (user == null)
            {
                account.RegisterDate = DateTime.Now;
                _dbContext.Add(account);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateAccount(Account account)
        {
            Account user = GetAccountByID(account.AccountId);
            if (user != null)
            {
                user.Address = account.Address;
                user.IdentityCard = account.IdentityCard;
                user.PhoneNumber = account.PhoneNumber;
                user.Email = account.Email;
                user.Password = account.Password;
                user.Status = account.Status;
                user.DateOfBirth = account.DateOfBirth;
                user.FullName = account.FullName;
                user.RoleId = account.RoleId;
                user.Image = account.Image;
                user.Gender = account.Gender;
                user.Username = account.Username;
                _dbContext.SaveChanges();
            }
        }
        public void DeleteAccount(Account account)
        {
            Account user = GetAccountByID(account.AccountId);
            if (user != null)
            {
                _dbContext.Remove(account);
                _dbContext.SaveChanges();
            }
        }
        public bool IsEmailExist(Account account)
        {
            var email = _dbContext.Accounts.FirstOrDefault(e => e.Email.Equals(account.Email));
            if (email != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsUsernameExist(Account account)
        {
            var username = _dbContext.Accounts.FirstOrDefault(e => e.Username.Equals(account.Username));
            if (username != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Register(Account account)
        {
            Account user = GetAccountByID(account.AccountId);
            if (user == null)
            {
                account.RegisterDate = DateTime.Now;
                account.RoleId = 2;
                account.Status = 0;
                _dbContext.Add(account);
                _dbContext.SaveChanges();
            }
        }
    }
}