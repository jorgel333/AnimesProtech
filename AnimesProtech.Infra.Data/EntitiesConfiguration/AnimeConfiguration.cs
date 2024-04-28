using AnimesProtech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimesProtech.Infra.Data.EntitiesConfiguration;

public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("Animes");

        builder.HasKey(x => x.Id).HasName("PK_Id");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

        builder.Property(x => x.Summary).IsRequired().HasMaxLength(600);

        builder.HasOne(x => x.Director).WithMany(x => x.Animes).HasForeignKey(x => x.DirectorId).HasConstraintName("FK_Animes_Directors");
    }
}
