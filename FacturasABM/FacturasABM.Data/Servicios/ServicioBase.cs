using FacturasABM.Core.Entidades;
using FacturasABM.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
			try
			{
				return await _context.Set<T>().ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}			
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			try
			{
				T? entity = await _context.Set<T>()
								.Where(t => EF.Property<int>(t, "Id") == id)
								.FirstOrDefaultAsync();

				if (entity == null)
				{
					throw new Exception($"Entidad del tipo {typeof(T).Name} con ID {id} no encontrada.");
				}

				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		public virtual async Task AddAsync(T item)
		{
			try
			{
				await _context.Set<T>().AddAsync(item);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		public virtual async Task UpdateAsync(T item)
		{
			try
			{
				_context.Set<T>().Update(item);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		public virtual async Task<T> DeleteAsync(int id)
		{
			try
			{
				T? entity = await _context.Set<T>().FindAsync(id);

				if (entity == null)
				{
					throw new Exception($"Entidad del tipo {typeof(T).Name} con ID {id} no encontrada.");
				}

				_context.Set<T>().Remove(entity);
				_context.SaveChanges();

				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}			
		}	
	}
}
