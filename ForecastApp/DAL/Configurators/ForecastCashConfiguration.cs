using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurators
{
    internal class ForecastCashConfiguration : IEntityTypeConfiguration<ForecastCash>
    {
        public void Configure(EntityTypeBuilder<ForecastCash> builder)
        {
            builder.HasKey(x => x.LastUpdatedDateTime);
        }
    }
}
