using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AquaQuality.DAL.Entities;

namespace AquaQuality.DAL.Mappings
{
    public class MeasurementsMapping : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nitrities)
              .IsRequired();
            builder.Property(m => m.Nitrates)
               .IsRequired();
            builder.Property(m => m.SuspendedSolids)
               .IsRequired();
            builder.Property(m => m.Ammonia)
               .IsRequired();
            builder.Property(m => m.Ferrum)
                .IsRequired();
            builder.Property(m => m.Phosphates)
                .IsRequired();
            builder.Property(m => m.Date)
                .IsRequired();
            builder.Property(m => m.WaterStorageId)
                .IsRequired();

            builder.ToTable("Measurements");
        }
    }
}
