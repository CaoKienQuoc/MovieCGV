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
    public class LoginRepository : ILoginRepository
    {
        public Account GetAccountByEmail(string email) => LoginDAO.Instance.GetAccountByEmail(email);
    }
}
