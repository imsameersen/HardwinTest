using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardwin.DAL
{
    public class LoginRepository : BaseRepository
    {
        public bool Login(Login loginModel)
        {
            var user = DbContext.UserLogin(loginModel.Email, loginModel.Password).FirstOrDefault();
            return user != null ? true : false;
        }

    }
}
