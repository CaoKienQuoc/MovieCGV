using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Interface
{
    public interface ILoginService
    {
        public Account GetAccountByEmail(string email);
    }
}
