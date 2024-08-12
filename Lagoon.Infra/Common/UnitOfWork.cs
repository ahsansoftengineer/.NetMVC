using Lagoon.App.Common;
using Lagoon.App.Repo;
using Lagoon.Infra.Repo;

namespace Lagoon.Infra.Common;
public class UnitOfWork : IUnitOfWork
{
  private readonly AppDBContext _db;
    public IRepoAmenity Amenity  { get; private set; }
  public IRepoVilla Villa { get; private set; }
  public IRepoVillaNumber VillaNumber { get; private set; }


    public UnitOfWork(AppDBContext db)
  {
    _db = db;
    
    Amenity = new RepoAmenity(_db);
    Villa = new RepoVilla(_db);
    VillaNumber = new RepoVillaNumber(_db);
  }

  public void Save()
  {
    _db.SaveChanges();
  }
}