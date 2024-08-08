using System.Linq.Expressions;

namespace Lagoon.App.Common.Interface;
public interface IRepoGeneric<T>
where T : class
{
  void Save();
  void Add(T entity);
  void Update(T entity);
  void Remove(T entity);
  IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? include = null);
  T? Get(Expression<Func<T, bool>> filter, string? include = null);
}