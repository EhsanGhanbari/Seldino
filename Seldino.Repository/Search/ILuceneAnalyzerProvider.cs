using Lucene.Net.Analysis;

namespace Seldino.Repository.Search
{
    public interface ILuceneAnalyzerProvider
    {
        Analyzer GetAnalyzer(string indexName);
    }
}