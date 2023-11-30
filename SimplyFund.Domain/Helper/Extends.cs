using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Helper
{
    public static class Extends
    {
  
            public static string GetJson<T>(this string str, T obj) where T : new()
            {
                return JsonConvert.SerializeObject(obj);
            }

                public static string GetJson<T>(T obj)
                {
                    return JsonConvert.SerializeObject(obj);
                }

    }
}
