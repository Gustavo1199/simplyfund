using SimplyFund.Domain.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Common
{
    public interface IServicesExpenses
    {
        Task<ExpensesModelsLists> getAuthomaticExpenses(ConditionRequest model);
    }
}
