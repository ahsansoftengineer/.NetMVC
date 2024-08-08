using Lagoon.App.Common.Interface;
using Lagoon.Domain.Entity;

namespace Lagoon.App.Common;
public interface IRepoVilla : IRepoGeneric<Villa>
{
  void Update(Villa entity);
  void Save();

  
}