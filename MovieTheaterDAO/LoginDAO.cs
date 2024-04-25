using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterDAO
{
    public class LoginDAO
    {
        private readonly MovieTheaterCGVContext _dbContext;
        private static LoginDAO _instance;

        public LoginDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static LoginDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginDAO();
                }
                return _instance;
            }
        }

        public Account GetAccountByEmail(string email)
        {
            try
            {
                return _dbContext.Accounts.AsNoTracking().FirstOrDefault(e => e.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
