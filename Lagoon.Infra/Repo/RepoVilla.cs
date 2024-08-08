using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Lagoon.Infra.Data;

namespace Lagoon.Infra.Repo;
public class RepoVilla : RepoGeneric<Villa>, IRepoVilla
{
  private readonly AppDBContext _db;
  public RepoVilla(AppDBContext db): base(db)
  {
    _db = db;
  }
  public void Save()
  {
    _db.SaveChanges();
  }

  public void Update(Villa entity)
  {
    _db.Villas.Update(entity);
  }
}