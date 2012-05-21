using System;
using System.Linq.Expressions;

namespace HP.SW.SWT.Entities
{
    public class PagingOptions
    {
        private static int DefaultPageSize = 100;

        public PagingOptions()
        {
            PageSize = DefaultPageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int SortColumn { get; set; }
        public bool Ascending { get; set; }

        public bool FirstPage
        {
            get
            {
                return this.Page == 1;
            }
        }

        public int FirstRowNumber
        {
            get
            {
                return DefaultPageSize * (this.Page - 1) + 1;
            }
        }

        public int LastRowNumber
        {
            get
            {
                return Math.Min(DefaultPageSize * this.Page, this.Count);
            }
        }

        public bool LastPage
        {
            get
            {
                return this.LastRowNumber == this.Count;
            }
        }

        public Expression GetExpression()
        {
            throw new NotImplementedException();
        }
    }
}