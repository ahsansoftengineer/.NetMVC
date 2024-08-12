using Lagoon.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Seed;
public static partial class SeedData
{
  public static void Villa(ModelBuilder builder)
  {
    builder.Entity<Villa>().HasData(
      new
      Villa
      {
        ID = 1,
        Name = "Royal Villa 1",
        Desc = "No Desc",
        ImageUrl = "https://placehold.co/600x400",
        Price = 200,
        Sqft = 550,
      },
      new Villa
      {
        ID = 2,
        Name = "Royal Villa 2",
        Desc = "No Desc",
        ImageUrl = "https://placehold.co/600x400",
        Price = 200,
        Sqft = 550,
      },
      new Villa
      {
        ID = 3,
        Name = "Royal Villa 3",
        Desc = "No Desc",
        ImageUrl = "https://placehold.co/600x400",
        Price = 200,
        Sqft = 550,
      }
    );
  }
}