using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        Setting GetDefault();
    }
}
