using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Models;

namespace TravelApp.Data.Configuration;

public class PaisDestinoConfiguration : IEntityTypeConfiguration<PaisDestino>
{
    public void Configure(EntityTypeBuilder<PaisDestino> builder)
    {
    }
}