﻿using FacturasABM.Controllers;
using FacturasABM.Core.Constantes;
using FacturasABM.Core.DTOs;
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

		[HttpGet]
		[Route("Con-filtros")]
		public async Task<ActionResult<IEnumerable<Factura>>> GetConFiltrosAsync([FromQuery] FiltrosFacturaDto filtros)
		{
			var resultados = await ((FacturaServicio)service).GetFacturasAsync(filtros);
			return Ok(resultados);
		}

		[HttpPost]
		//[Route("crear-factura")]
		public async Task<ActionResult<IEnumerable<Factura>>> CrearAsync(CrearFacturaDto input)
		{
			var resultado = await ((FacturaServicio)service).CrearFacturaAsync(input);
			return Ok(resultado);
		}

		[HttpPut]
		public async Task<ActionResult<Factura>> EditarAsync(int id, EstadoFactura estado)
		{
			var factura = await service.UpdateAsync(new Factura()
			{
				Id = id,
				Estado = estado
			});

			return Ok(factura);
		}
	}
}
