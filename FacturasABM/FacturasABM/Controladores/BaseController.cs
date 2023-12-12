using FacturasABM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FacturasABM.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BaseController<T> : ControllerBase
	{
		protected readonly FacturasDbContext _context;
		protected IServicio<T> service;

		public BaseController(FacturasDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<T>> GetByIdAsync(int id)
		{
			var result = await service.GetByIdAsync(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
		{
			var results = await service.GetAllAsync();
			return Ok(results);
		}

		[HttpPost]
		public async Task<ActionResult<T>> AddAsync(T item)
		{
			await service.AddAsync(item);
			return Ok(await service.GetAllAsync());
		}

		[HttpPut]
		public async Task<ActionResult<T>> Put(T item)
		{
			await service.UpdateAsync(item);
			return Ok(await service.GetAllAsync());
		}

		[HttpDelete]
		public async Task<ActionResult<T>> DeleteAsync(int id)
		{
			T entity = await service.DeleteAsync(id);
			return Ok(entity);
		}
	}
}
