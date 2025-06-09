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
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new DestinoConfiguration());
        modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
        modelBuilder.ApplyConfiguration(new ReservaConfiguration());
    }
}