using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Enums
{
    public static class RequestEstatusEnum
    {
        public static string revisión => "En revisión";
        public static string Devuelta => "Devuelta";
        public static string Rechazada => "Rechazada";
        public static string aprobación => "En aprobación";
        public static string marketplace => "En marketplace";
        public static string Formalización => "En Formalización";
        public static string curso => "En curso";
        public static string Finalizada => "Finalizada";
        public static string Eliminada => "Eliminada";
      
    }
}
