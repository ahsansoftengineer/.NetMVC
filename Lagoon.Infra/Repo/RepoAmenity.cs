using Lagoon.App.Repo;
using Lagoon.Domain.Entity;
using Lagoon.Infra.Common;

namespace Lagoon.Infra.Repo;
public class RepoAmenity : RepoGeneric<Amenity>, IRepoAmenity
{
  private readonly AppDBContext _db;
  public RepoAmenity(AppDBContext db) : base(db)
  {
    _db = db;
  }
  public void Update(Amenity entity)
  {
    _db.Amenity.Update(entity);
  }
}