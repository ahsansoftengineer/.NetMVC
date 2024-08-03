using Lagoon.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Data;
public class AppDBContext : DbContext 
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
  {
    
  }
  public DbSet<Villa> Villas {get;set;}
}