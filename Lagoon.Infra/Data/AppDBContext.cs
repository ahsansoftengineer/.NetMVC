using Lagoon.Domain.Entity;
using Lagoon.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Data;
public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  { 

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    SeedData.Villa(modelBuilder);
    base.OnModelCreating(modelBuilder);
  }
  public DbSet<Villa> Villas { get; set; }
}