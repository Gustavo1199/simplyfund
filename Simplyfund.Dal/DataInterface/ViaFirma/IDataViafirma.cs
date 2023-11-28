using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.DataInterface.ViaFirma
{
    public interface IDataViafirma
    {
        Task<string> httpPostRequest(string content, string enpoint);
    }
}
