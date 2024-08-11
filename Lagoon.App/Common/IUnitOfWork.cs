namespace Lagoon.App.Common;
public interface IUnitOfWork
{
     IRepoVilla Villa { get; }
     void Save();
}