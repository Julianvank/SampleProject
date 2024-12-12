using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Extensions.Configuration;

public static class StockConfiguration
{
    public static void ConfigureModel(this EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(id => id.Id);
        builder.Property(id => id.Id).ValueGeneratedOnAdd();
    }
}