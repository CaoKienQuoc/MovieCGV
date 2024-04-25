using BusinessObject.Datalayer;
using MovieTheaterRepo.Interface;
using MovieTheaterService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AddAccount(Account account)
        => _accountRepository.AddAccount(account);

        public void DeleteAccount(Account account)
        => _accountRepository.DeleteAccount(account);

        public Account GetAccountByID(int? id)
        => _accountRepository.GetAccountByID(id);

        public List<Account> GetAllAccount()
        => _accountRepository.GetAllAccount();

        public bool IsEmailExist(Account account)
        => _accountRepository.IsEmailExist(account);

        public bool IsUsernameExist(Account account)
        => _accountRepository.IsUsernameExist(account);

        public void Register(Account account)
        => _accountRepository.Register(account);

        public void UpdateAccount(Account account)
        => _accountRepository.UpdateAccount(account);
    }
}