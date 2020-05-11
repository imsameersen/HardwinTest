using HardWin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = Hardwin.DAL;

namespace Hardwin.BAL
{
    public class LoginBL
    {
        private readonly DAL.LoginRepository loginRepository;
        public LoginBL()
        {
            this.loginRepository = new DAL.LoginRepository();
        }

        public bool Login(Login loginModel)
        {
            var model = new DAL.Login()
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };
            return loginRepository.Login(model);
        }

    }
}
