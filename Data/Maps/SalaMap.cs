using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgendamentoReunioesApp.Models;

namespace AgendamentoReunioesApp.Data.Maps
{
    public class SalaMap : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Sala");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
        }
    }
}