using FacturasABM.Core.DTOs;
using FacturasABM.Core.Servicios;
using FacturasABM.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasABM.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmpresaController : BaseController<Empresa>
	{
		public EmpresaController(FacturasDbContext context) : base(context)
		{
			service = new EmpresaServicio(_context);
		}

		[HttpPost]
		public async Task<ActionResult<Empresa>> CrearAsync(CrearEditarEmpresaDto input)
		{
			var empresa = await service.AddAsync(new Empresa() 
			{ 
				CIF = input.CIF,
				RazonSocial = input.RazonSocial
			});

			return Ok(empresa);
		}

		[HttpPut]
		public async Task<ActionResult<Empresa>> EditarAsync(int id, CrearEditarEmpresaDto input)
		{
			var empresa = await service.UpdateAsync(new Empresa()
			{
				Id = id,
				CIF = input.CIF,
				RazonSocial = input.RazonSocial
			});

			return Ok(empresa);
		}
	}
}
