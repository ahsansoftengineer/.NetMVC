using Lagoon.Domain.Entity;
using Lagoon.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Common;
public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  { 

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    SeedData.Villa(modelBuilder);
    SeedData.VillaNumber(modelBuilder);
    base.OnModelCreating(modelBuilder);
  }
  public DbSet<Villa> Villas { get; set; }
  public DbSet<VillaNumber> VillaNumber { get; set; }
}