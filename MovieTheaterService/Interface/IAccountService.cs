using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Interface
{
    public interface IAccountService
    {
        public List<Account> GetAllAccount();
        public Account GetAccountByID(int? id);
        public void AddAccount(Account account);
        public void UpdateAccount(Account account);
        public void DeleteAccount(Account account);
        public bool IsEmailExist(Account account);
        public bool IsUsernameExist(Account account);
        public void Register(Account account);
    }
}