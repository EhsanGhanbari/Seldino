using System.Linq;
using Seldino.Domain.SettingAggregation;
using Seldino.Repository.Infrastructure;
using System.Data.Entity;

namespace Seldino.Repository.Repositories
{
    internal class SettingRespository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRespository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public Setting GetDefault()
        {
            return DataContext.Settings
                .Include(c => c.BannerSetting)
                .Include(c => c.BasicSetting)
                .Include(c => c.BasketSetting)
                .Include(c => c.DiscountSetting)
                .Include(c => c.DocumentSetting)
                .Include(c => c.OrderSetting)
                .Include(c => c.ProductSetting)
                .Include(c => c.BlogSetting)
                .Include(c => c.StoreSetting)
                .LastOrDefault();
        }
    }
}
