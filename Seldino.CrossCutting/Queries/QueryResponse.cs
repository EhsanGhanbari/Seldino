using Seldino.CrossCutting.Enums;

namespace Seldino.CrossCutting.Queries
{
    public abstract class QueryResponse
    {
        public bool Failed { get; set; }

        public string Message { get; set; }

        public QueryMessageType MessageType { get; set; }
    }
}
