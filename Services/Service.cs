using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using stud_bud_back.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Services
{
	public interface IService<T> where T : class
	{
		public Task<T> Create(T entity);
		public Task<int> Delete(int id);
		public Task<IEnumerable<T>> GetAll();
		public Task<T> GetById(int id);
		public Task<bool> Exists(int id);
	}


	public abstract class Service<T> : IService<T> where T : class
	{
		protected DataContext _context;

		public Service(DataContext context)
		{
			_context = context;
		}

		public virtual async Task<T> Create(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<int> Delete(int id)
		{
			T foundEntity = await GetById(id);

			if (foundEntity == null)
				throw new AppException($"The {typeof(T)} you're trying to delete doesn't exist");

			_context.Set<T>().Remove(foundEntity);
			return await _context.SaveChangesAsync();
		}

		public virtual async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public virtual async Task<T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public virtual async Task<bool> Exists(int id)
		{
			return await _context.Set<T>().FindAsync(id) != null;
		}
	}
}
