using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Common
{
    public class ExpensesModelsLists
    {
        public List<ExpenseDto> AutomaticsExpense { get; set; }
        public List<ExpenseDto> ElegibleExpense { get; set; }

        public ExpensesModelsLists()
        {
            AutomaticsExpense = new List<ExpenseDto>();
            ElegibleExpense = new List<ExpenseDto>();
        }
    }
}
