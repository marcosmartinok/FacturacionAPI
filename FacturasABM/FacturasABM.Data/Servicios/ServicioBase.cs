using FacturasABM.Core.Entidades;
using FacturasABM.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Servicios
{
	public class ServicioBase<T> : IServicio<T> where T : EntidadBase
	{
		protected FacturasDbContext _context;
		public ServicioBase(FacturasDbContext context)
		{
			_context = context;
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			T? entity = await _context.Set<T>()
					   .Where(t => EF.Property<int>(t, "Id") == id)
					   .FirstOrDefaultAsync();

			if (entity == null)
			{
				throw new Exception($"Entity of type {typeof(T).Name} with ID {id} not found.");
			}

			return entity;
		}

		public virtual async Task AddAsync(T item)
		{
			await _context.Set<T>().AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public virtual async Task UpdateAsync(T item)
		{
			_context.Set<T>().Update(item);
			await _context.SaveChangesAsync();
		}

		public virtual async Task<T> DeleteAsync(int id)
		{
			T? entity = await _context.Set<T>().FindAsync(id);

			if (entity == null)
			{
				throw new Exception($"Entity of type {typeof(T).Name} with ID {id} not found.");
			}

			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
			return entity;
		}	
	}
}
