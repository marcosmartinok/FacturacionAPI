using FacturasABM.Core.Constantes;
using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.DTOs
{
	public class FiltrosFacturaDto
	{
		public int? IdFactura { get; set; }
		public string GUIDFactura { get; set; }
		public string NumFactura { get; set; }
		public EstadoFactura? Estado { get; set; }
		public int? IdEmpresa { get; set; }
		public int? IdPersona { get; set; }

		public FiltrosFacturaDto() 
		{
			GUIDFactura = string.Empty;
			NumFactura = string.Empty;
		}
	}
}
