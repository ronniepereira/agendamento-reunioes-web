using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgendamentoReunioesApp.Models;

namespace AgendamentoReunioesApp.Data.Maps
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.HoraInicio).IsRequired();
            builder.Property(x => x.HoraFim).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();

            builder.HasOne(x => x.Sala).WithMany(x => x.Agendamentos);
        }
    }
}