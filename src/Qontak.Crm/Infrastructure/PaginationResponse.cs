using System.Collections.Generic;

namespace Qontak.Crm
{
    public class PaginationResponse<T>
    {
        public List<T> Data { get; set; }

        public int Page { get; set; }

        public int TotalPage { get; set; }

        public int CurrentData { get; set; }

        public int? TotalData { get; set; }
    }
}
