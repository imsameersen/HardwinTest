﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWin.Entities
{
    public class AccountSearchFilter
    {
       public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Decimal? Amount { get; set; }
    }
}
