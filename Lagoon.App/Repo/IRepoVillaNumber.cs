using Lagoon.App.Common;
using Lagoon.Domain.Entity;

namespace Lagoon.App.Repo;
public interface IRepoVillaNumber: IRepoGeneric<VillaNumber>
{
  void Update(VillaNumber entity);
}