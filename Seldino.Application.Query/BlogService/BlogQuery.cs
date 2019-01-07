using System;
using Seldino.CrossCutting.Paging;

namespace Seldino.Application.Query.BlogService
{
    public class BlogQuery : PagingQueryRequest
    {
        public Guid Id { get; set; }
        public string Keyword { get; set; }
        public string Value { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string UrlSlug { get; set; }

        public BlogQuery() { }

        public BlogQuery(Guid id)
        {
            Id = id;
        }

        public BlogQuery(string keyword)
        {
            Keyword = keyword;
        }

        public BlogQuery(Guid id, string keyword)
        {
            Id = id;
            Keyword = keyword;
        }

        public BlogQuery(string keyword, string value)
        {
            Keyword = keyword;
            Value = value;
        }

        public BlogQuery(int year, int month, int day, string urlSlug)
        {
            Year = year;
            Month = month;
            Day = day;
            UrlSlug = urlSlug;
        }
    }
}
