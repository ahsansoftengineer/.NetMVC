using Lagoon.App.Repo;

namespace Lagoon.App.Common;
public interface IUnitOfWork
{
     IRepoAmenity Amenity { get; }
     IRepoVilla Villa { get; }
     IRepoVillaNumber VillaNumber { get; }
     void Save();
}