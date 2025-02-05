using Lagoon.App.Repo;
using Lagoon.Domain.Entity;
using Lagoon.Infra.Common;

namespace Lagoon.Infra.Repo;
public class RepoVillaNumber : RepoGeneric<VillaNumber>, IRepoVillaNumber
{
  private readonly AppDBContext _db;
  public RepoVillaNumber(AppDBContext db): base(db)
  {
    _db = db;
  }
  public void Update(VillaNumber entity)
  {
    _db.VillaNumber.Update(entity);
  }
}