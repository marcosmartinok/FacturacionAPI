using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Interfaces
{
	public interface IServicio<T>
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task AddAsync(T item);
		Task UpdateAsync(T item);
		Task<T> DeleteAsync(int id);
	}
}
