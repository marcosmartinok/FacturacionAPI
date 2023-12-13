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
	}
}
