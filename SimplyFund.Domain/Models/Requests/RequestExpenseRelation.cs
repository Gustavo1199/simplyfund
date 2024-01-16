using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Requests
{
    public class RequestExpenseRelation : EntityBase
    {
        public int RequestID { get; set; }

       // public Request? Request { get; set; }

        public int ExpenseID { get; set; }

        public virtual Expense? Expense { get; set; }

        public decimal? Amount { get; set; }


    }
}
