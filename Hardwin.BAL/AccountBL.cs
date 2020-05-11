using HardWin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardwin.BAL
{
    public class AccountBL
    {
        private readonly DAL.AccountRepository accountRepository;
        public AccountBL()
        {
            accountRepository = new DAL.AccountRepository();
        }

        public Account CreateAccount(Account record)
        {
            var dbAccount = new DAL.Account
            {
                FirstName = record.FirstName,
                LastName = record.LastName,
                Email = record.Email,
                Phone = record.Phone,
                Address = record.Address,
                Country = record.Country,
                State = record.State,
                Amount = record.Amount
            };
            var result = accountRepository.CreateAccount(dbAccount);
            if (result > 0)
            {
                record.Id = result;
                return record;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Account> GetAccounts(AccountSearchFilter searchFilter)
        {
            var accounts = accountRepository.GetAccounts(searchFilter).Select(x => new Account
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                Country = x.Country,
                State = x.State,
                Amount = x.Amount
            });
            return accounts;
        }


    }
}
