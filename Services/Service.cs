using Microsoft.EntityFrameworkCore;
using stud_bud_back.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Services
{
	public interface IService<T> where T : class
	{
		public Task<int> Create(T entity);
		public Task<int> Delete(int id);
		public Task<IEnumerable<T>> GetAll();
		public Task<T> Get(int id);
	}


	public abstract class Service<T> : IService<T> where T : class
	{
		protected DataContext _context;

		public Service(DataContext context)
		{
			_context = context;
		}

		public async Task<int> Create(T entity)
		{
			_context.Set<T>().Add(entity);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> Delete(int id)
		{
			T foundEntity = _context.Set<T>().Find(id);

			if (foundEntity == null)
				throw new AppException("The " + typeof(T).Name.ToLower() + " you're trying to delete doesn't exist");

			_context.Set<T>().Remove(foundEntity);
			return await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> Get(int id)
		{
			T foundEntity = await _context.Set<T>().FindAsync(id);

			if (foundEntity == null)
				throw new AppException("The " + typeof(T).Name.ToLower() + " you're trying to find doesn't exist");

			return foundEntity;
		}
	}
}
