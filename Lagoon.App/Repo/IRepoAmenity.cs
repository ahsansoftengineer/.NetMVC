using Lagoon.App.Common;
using Lagoon.Domain.Entity;

namespace Lagoon.App.Repo;
public interface IRepoAmenity: IRepoGeneric<Amenity>
{
  void Update(Amenity entity);
}