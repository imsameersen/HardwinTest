using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardwin.DAL.AdoHelper;

namespace Hardwin.DAL
{
    public class BaseRepository
    {
        protected HardwinDbContext DbContext;
        protected DbHelper DbHelper;
        public BaseRepository()
        {
            this.DbContext = new HardwinDbContext();
            this.DbHelper = new DbHelper();
        }
    }
}
