using AnimesProtech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimesProtech.Infra.Data.EntitiesConfiguration;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors");

        builder.HasKey(x => x.Id).HasName("PK_Director");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

        builder.HasMany(x => x.Animes).WithOne(x => x.Director).HasForeignKey(x => x.DirectorId).HasConstraintName("FK_Animes_Directors");
    }
}
