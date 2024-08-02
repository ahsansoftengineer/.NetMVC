using Lagoon.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace WhiteLagoon.Infra.Data;
public class AppDBContext : DbContext 
{
     DbSet<Villa> villas {get;set;}
}