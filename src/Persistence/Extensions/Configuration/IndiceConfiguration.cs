using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Extensions.Configuration;

public static class IndiceConfiguration
{
   public static void ConfigureModel(this EntityTypeBuilder<Indice> builder)
   {
      builder.HasKey(id => id.Id);
      builder.Property(id => id.Id).ValueGeneratedOnAdd();
      builder.HasMany(d => d.Stocks);
   } 
}