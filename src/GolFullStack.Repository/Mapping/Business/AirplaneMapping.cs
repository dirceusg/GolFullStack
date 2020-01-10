using System;
using GolFullStack.Entity.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GolFullStack.Repository.Mapping.Business
{
    public class AirplaneMapping : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Modelo)
                .IsRequired();

            builder.Property(x => x.QuantidadePassageiros)
                .IsRequired();

            builder.ToTable("Airplane", "neg");

        }
    }
}
