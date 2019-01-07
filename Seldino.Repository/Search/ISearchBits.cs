using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Logging;


namespace Seldino.Repository.Search
{
    public interface ISearchBits
    {
        ISearchBits And(ISearchBits other);

        ISearchBits Or(ISearchBits other);

        ISearchBits Xor(ISearchBits other);

        long Count();
    }
}
