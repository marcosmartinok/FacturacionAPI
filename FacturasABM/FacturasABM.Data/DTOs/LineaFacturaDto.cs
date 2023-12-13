using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.DTOs
{
	public class LineaFacturaDto
	{
		public decimal Importe { get; set; }
		public decimal IVA { get; set; }
	}
}
