using FacturasABM.Core.DTOs;
using FacturasABM.Core.Servicios;
using FacturasABM.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace FacturasABM.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonaController : BaseController<Persona>
	{
		public PersonaController(FacturasDbContext context) : base(context)
		{
			service = new PersonaServicio(_context);
		}

		[HttpPost]
		public async Task<ActionResult<Persona>> CrearAsync(CrearEditarPersonaDto input)
		{
			var persona = await service.AddAsync(new Persona()
			{
				Nombre = input.Nombre,
				Apellido1 = input.Apellido1,
				Apellido2 = input.Apellido2,
				NIF = input.NIF
			});

			return Ok(persona);
		}

		[HttpPut]
		public async Task<ActionResult<Persona>> EditarAsync(int id, CrearEditarPersonaDto input)
		{
			var persona = await service.UpdateAsync(new Persona()
			{
				Id = id,
				Nombre = input.Nombre,
				Apellido1 = input.Apellido1,
				Apellido2 = input.Apellido2,
				NIF = input.NIF
			});

			return Ok(persona);
		}
	}
}
