using Microsoft.EntityFrameworkCore;
using AgendamentoReunioesApp.Data.Maps;
using AgendamentoReunioesApp.Models;

namespace AgendamentoReunioesApp.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=localhost,5434;Database=agendamentoreuniao_app;User ID=SA;Password=Pass@word");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AgendamentoMap());
            builder.ApplyConfiguration(new SalaMap());
        }
    }
}