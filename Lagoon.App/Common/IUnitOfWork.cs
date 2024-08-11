using Lagoon.App.Repo;

namespace Lagoon.App.Common;
public interface IUnitOfWork
{
     IRepoVilla Villa { get; }
     IRepoVillaNumber VillaNumber { get; }
     void Save();
}