using Microsoft.EntityFrameworkCore;
using TravelApp.Data.Configuration;
using TravelApp.Models;

namespace TravelApp.Data;

public class TravelAppContext : DbContext
{
    public TravelAppContext(DbContextOptions<TravelAppContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<CidadeDestino> Cidades { get; set; }
    public DbSet<PaisDestino> Paises { get; set; }
    public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        modelBuilder.ApplyConfiguration(new CidadeDestinoConfiguration());
        modelBuilder.ApplyConfiguration(new PaisDestinoConfiguration());
        modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
    }
}