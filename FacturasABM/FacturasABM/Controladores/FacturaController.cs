using FacturasABM.Controllers;
using FacturasABM.Core.Servicios;
using FacturasABM.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasABM.Controladores
{
	[ApiController]
	[Route("[controller]")]
	public class FacturaController : BaseController<Factura>
	{
		public FacturaController(FacturasDbContext context) : base(context)
		{
			service = new FacturaServicio(_context);
		}
	}
}
