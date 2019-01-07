using Seldino.Domain.LocationAggregation;
using Seldino.Repository.Infrastructure;
using System.Data;

namespace Seldino.Repository.Configurations
{
    internal class LocationConfiguration : EntityBaseConfiguration<Location>
    {
        public LocationConfiguration()
        {
            ToTable("Location", SchemaConstant.Location);

            Property(l => l.CountryName).HasMaxLength(50).IsRequired();
            HasRequired(l => l.Country).WithMany().HasForeignKey(p => p.CountryName).WillCascadeOnDelete(false);

            Property(l => l.StateName).HasMaxLength(50).IsRequired();
            HasRequired(l => l.State).WithMany().HasForeignKey(p => p.StateName).WillCascadeOnDelete(false);

            Property(l => l.AddressId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(l => l.Address).WithMany().HasForeignKey(p => p.AddressId).WillCascadeOnDelete(false);

            Property(l => l.Latitude).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 15).IsRequired();
            Property(l => l.Longitude).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 15).IsRequired();
        }
    }

    internal class CountryConfiguration : ValueObjectBaseConfiguration<Country>
    {
        public CountryConfiguration()
        {
            ToTable("Country", SchemaConstant.Location);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(100);

            HasMany(c => c.States).WithMany(s => s.Countries).Map(m =>
            {
                m.MapLeftKey("CountryName");
                m.MapRightKey("StateName");
                m.ToTable("Country_State", SchemaConstant.Location);
            });
        }
    }

    internal class StateConfiguration : ValueObjectBaseConfiguration<State>
    {
        public StateConfiguration()
        {
            ToTable("State", SchemaConstant.Location);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(100);

            HasMany(c => c.Cities).WithMany(s => s.States).Map(m =>
            {
                m.MapLeftKey("StateName");
                m.MapRightKey("CityName");
                m.ToTable("State_City", SchemaConstant.Location);
            });
        }
    }

    internal class CityConfiguration : ValueObjectBaseConfiguration<City>
    {
        public CityConfiguration()
        {
            ToTable("City", SchemaConstant.Location);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(100);

            HasMany(c => c.Regions).WithMany(s => s.Cities).Map(m =>
            {
                m.MapLeftKey("CityName");
                m.MapRightKey("RegionName");
                m.ToTable("City_Region", SchemaConstant.Location);
            });
        }
    }

    internal class AreaConfiguration : ValueObjectBaseConfiguration<Area>
    {
        public AreaConfiguration()
        {
            ToTable("Area", SchemaConstant.Location);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }

    internal class RegionConfiguration : ValueObjectBaseConfiguration<Region>
    {
        public RegionConfiguration()
        {
            ToTable("Region", SchemaConstant.Location);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);

            HasMany(c => c.Areas).WithMany(s => s.Regions).Map(m =>
            {
                m.MapLeftKey("RegionName");
                m.MapRightKey("AreaName");
                m.ToTable("Region_Area", SchemaConstant.Location);
            });
        }
    }

    internal class AddressConfiguration : EntityBaseConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Address", SchemaConstant.Location);
            Property(a => a.AddressLine).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
            Property(a => a.City).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(80);
            Property(a => a.ZipCode).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(20);
        }
    }
}
