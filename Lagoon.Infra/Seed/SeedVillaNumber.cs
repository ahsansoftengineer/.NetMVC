using Lagoon.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Seed;
public static partial class SeedData
{
  public static void VillaNumber(ModelBuilder builder)
  {
    builder.Entity<VillaNumber>().HasData(
      new VillaNumber
      {
        Villa_Number = 101,
        VillaId = 1
      },
      new VillaNumber
      {
        Villa_Number = 102,
        VillaId = 1
      },
      new VillaNumber
      {
        Villa_Number = 103,
        VillaId = 1
      },
      new VillaNumber
      {
        Villa_Number = 201,
        VillaId = 2
      },
      new VillaNumber
      {
        Villa_Number = 202,
        VillaId = 2
      },
      new VillaNumber
      {
        Villa_Number = 203,
        VillaId = 2
      }
    );
  }
}