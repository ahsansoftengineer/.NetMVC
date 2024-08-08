using System.Linq.Expressions;
using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Lagoon.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Infra.Repo;
public class RepoVilla : IRepoVilla
{
  private readonly AppDBContext _db;
  public RepoVilla(AppDBContext db)
  {
    _db = db;
  }
  public void Add(Villa entity)
  {
    _db.Villas.Add(entity);
  }
  public void Remove(Villa entity)
  {
    _db.Remove(entity);
  }
  public void Save()
  {
    _db.SaveChanges();
  }
  public void Update(Villa entity)
  {
    _db.Villas.Update(entity);
  }
  public Villa? Get(Expression<Func<Villa, bool>> filter, string? includes)
  {
     IQueryable<Villa> query = _db.Set<Villa>();
    if (filter != null)
    {
      query = query.Where(filter);
    }
    // Include Should be Case Sensitive
    if (!string.IsNullOrEmpty(includes))
    {
      var result = includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var include in result)
      {
        query = query.Include(include);
      }
    }
    return query.FirstOrDefault();
  }
  public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includes = null)
  {
    IQueryable<Villa> query = _db.Set<Villa>();
    if (filter != null)
    {
      query = query.Where(filter);
    }
    // Include Should be Case Sensitive
    if (!string.IsNullOrEmpty(includes))
    {
      var result = includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var include in result)
      {
        query = query.Include(include);
      }
    }
    return query.ToList();
  }
}