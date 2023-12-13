using FacturasABM.Core.Constantes;
using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.DTOs
{
	public class CrearFacturaDto
	{
		[Required]
		public string GUIDFactura { get; set; }

		[Required]
		public string NumFactura { get; set; }

		[Required]
		public EstadoFactura Estado { get; set; }

		[Range(1, int.MaxValue)]
		public int? IdEmpresa { get; set; }

		[Range(1, int.MaxValue)]
		public int? IdPersona { get; set; }
		public PersonaDto? PersonaNueva  { get; set; }

		public List<LineaFacturaDto> LineasFactura { get; set; }

		public CrearFacturaDto()
		{
			NumFactura = string.Empty;
			GUIDFactura = string.Empty;

			LineasFactura = new List<LineaFacturaDto>();
		}
	}
}
