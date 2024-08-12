using Lagoon.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Seed;
public static partial class SeedData
{
  public static void Amenity(ModelBuilder builder)
  {
    builder.Entity<Amenity>().HasData(
      new Amenity
      {
        ID = 1,
        Name = "Amenity 1",
        Desc = "Amenity 1 Desc",
        VillaId = 1
      },
      new Amenity
      {
        ID = 2,
        Name = "Amenity 2",
        Desc = "Amenity 2 Desc",
        VillaId = 2
      },
      new Amenity
      {
        ID = 3,
        Name = "Amenity 3",
        Desc = "Amenity 3 Desc",
        VillaId = 3
      }
    );
  }
}