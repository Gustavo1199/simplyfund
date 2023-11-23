using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Base.Filter
{
    public class FilterAndPaginateRequestModel
    {
        public List<(string? PropertyName, object? Value)>? Filters { get; set; }
        public required int PageIndex { get; set; }
        public required int PageSize { get; set; }
        public List<string>? IncludeProperties { get; set; } // Lista de propiedades a incluir
        public string? OrderProperty { get; set; }
        public string? OrderDirection { get; set; } //desc o asc
    }
}
