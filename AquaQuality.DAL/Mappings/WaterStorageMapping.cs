
using AquaQuality.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AquaQuality.DAL.Mappings
{
    internal class WaterStorageMapping : IEntityTypeConfiguration<WaterStorage>
    {
        public void Configure(EntityTypeBuilder<WaterStorage> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(w => w.City)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(w => w.CoordSouth)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(w => w.CoordNorth)
                 .IsRequired()
                 .HasColumnType("varchar(10)");

            builder.HasMany(w => w.Measurements)
                .WithOne(m => m.WaterStorage)
                .HasForeignKey(m => m.WaterStorageId);

            builder.ToTable("WaterStorages");
        }
    }
}
