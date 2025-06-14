using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Models;

namespace TravelApp.Data.Configuration;

public class CidadeDestinoConfiguration : IEntityTypeConfiguration<CidadeDestino>
{
    public void Configure(EntityTypeBuilder<CidadeDestino> builder)
    {
    }
}