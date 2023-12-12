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
	}
}
