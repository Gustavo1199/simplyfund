using Simplyfund.Dal.Data.BaseData;
using Simplyfund.Dal.DataBase;
using Simplyfund.Dal.DataInterface.Requests;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Data.Requests
{
    public class DataRequest : BaseDatas<Request>, IDataRequest
    {
        public DataRequest(SimplyfundDbContext context) : base(context)
        {
        }



        //public override async Task<Request> GetByIdAsync(int id)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
