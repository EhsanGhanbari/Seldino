using System;

namespace Seldino.CrossCutting.Queries
{
    public abstract class QueryRequest
    {
        public Guid LangaugeId { get; set; }

        public string Keyword { get; set; }

        public Guid UserId { get; set; }
    }
}
