using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Infrastructure.Data;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class {

	private readonly ApplicationDbContext _db;
	internal DbSet<T> dbSet;

	public Repository(ApplicationDbContext db) {
		_db = db;
		dbSet = _db.Set<T>();
	}

	public void Add(T entity) => dbSet.Add(entity);

	public bool Any(Expression<Func<T, bool>> filter) => dbSet.Any(filter);

	public void Remove(T entity) => dbSet.Remove(entity);

	public void Save() => _db.SaveChanges();

	private IEnumerable<string> ExtractProperties(string includeProperties) {
		var result = includeProperties
			.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
			.Select(x => x.Trim())
			.ToList();
		return result;
	}

	public T Get(
		Expression<Func<T, bool>> filter, string? includeProperties = null) {
		IQueryable<T> query = dbSet;

		if (filter is not null)
			query = query.AsExpandable().Where(filter);

		if (!string.IsNullOrEmpty(includeProperties)) {
			foreach (var property in ExtractProperties(includeProperties)) {
				query = query.Include(property);
			}
		}

		return query.FirstOrDefault();
		//return query.ToList();
	}

	public IEnumerable<T> GetAll(
		Expression<Func<T, bool>>? filter = null, string? includeProperties = null) {
		IQueryable<T> query = dbSet;

		if (filter is not null)
			query = query.Where(filter);

		if (!string.IsNullOrEmpty(includeProperties)) {
			foreach (var property in ExtractProperties(includeProperties)) {
				query = query.Include(property);
			}
		}

		return query.ToList();
	}
}
