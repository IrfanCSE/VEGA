using System.Collections.Generic;

namespace VEGA.Models.Dtos
{
    public class QueryResultDto<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}