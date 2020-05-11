using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardWin.Entities;
using System.Data;

namespace Hardwin.DAL
{
    public class AccountRepository : BaseRepository
    {
        public int CreateAccount(Account record)
        {
            var idParamerter = new SqlParameter("@AccountId", SqlDbType.Int);
            idParamerter.Direction = ParameterDirection.Output;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName",record.FirstName),
                new SqlParameter("@LastName",record.LastName),
                new SqlParameter("@Address",record.Address),
                new SqlParameter("@Phone",record.Phone),
                new SqlParameter("@State",record.State),
                new SqlParameter("@Country",record.Country),
                new SqlParameter("@Email",record.Email),
                new SqlParameter("@Amount",record.Amount),
                idParamerter
            };
            var result = DbHelper.NonQuery("uspAddAccount", parameters);
            return Convert.ToInt32(idParamerter.Value);
        }

        public IEnumerable<Account> GetAccounts(AccountSearchFilter searchFilter)
        {

            var accounts = DbContext.GetAccounts(searchFilter.FromDate, searchFilter.ToDate,searchFilter.Amount);
            return accounts.ToList();
        }



    }
}
