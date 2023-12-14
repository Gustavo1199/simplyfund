using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Base.Filter
{
    public class FilterAndPaginateRequestModel
    {
        public List<Filters>? Filters { get; set; }
        public required int PageIndex { get; set; }
        public required int PageSize { get; set; }
        public List<string>? IncludeProperties { get; set; } // Lista de propiedades a incluir
        public string? OrderProperty { get; set; }
        public string? OrderDirection { get; set; } //desc o asc
    }

    public class Filters
    {
        public string? PropertyName { get; set; }

        public object? Value { get; set; }
    }
}
