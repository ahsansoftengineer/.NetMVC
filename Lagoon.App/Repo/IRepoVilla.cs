using Lagoon.App.Common;
using Lagoon.Domain.Entity;

namespace Lagoon.App.Repo;
public interface IRepoVilla: IRepoGeneric<Villa>
{
  void Update(Villa entity);
}