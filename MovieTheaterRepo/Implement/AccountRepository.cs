using BusinessObject.Datalayer;
using MovieTheaterDAO;
using MovieTheaterRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Implement
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account account)
        => AccountDAO.Instance.AddAccount(account);

        public void DeleteAccount(Account account)
        => AccountDAO.Instance.DeleteAccount(account);

        public Account GetAccountByID(int? id)
        => AccountDAO.Instance.GetAccountByID(id);

        public List<Account> GetAllAccount()
        => AccountDAO.Instance.GetAllAccount();

        public bool IsEmailExist(Account account)
        => AccountDAO.Instance.IsEmailExist(account);

        public bool IsUsernameExist(Account account)
        => AccountDAO.Instance.IsUsernameExist(account);

        public void Register(Account account)
        => AccountDAO.Instance.Register(account);

        public void UpdateAccount(Account account)
        => AccountDAO.Instance.UpdateAccount(account);
    }
}