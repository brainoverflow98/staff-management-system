using System;
namespace PersonelTakip.Core
{
    public class IQueryObject
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string filter { get; set; }

        public IQueryObject()
        {

        }
    }
}
