using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Models.Response
{
    public class PageInfoResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PageInfoResponse(int CurrentPage, int TotalPages, int PageSize, int TotalCount, bool HasPrevious, bool HasNext)
        {
            this.CurrentPage = CurrentPage;
            this.TotalPages = TotalPages;
            this.PageSize = PageSize;
            this.TotalCount = TotalCount;
            this.HasPrevious = HasPrevious;
            this.HasNext = HasNext;
        }
    }
}
