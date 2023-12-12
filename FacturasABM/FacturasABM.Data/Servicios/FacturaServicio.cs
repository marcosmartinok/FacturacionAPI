using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Servicios
{
	public class FacturaServicio : ServicioBase<Factura>
	{
		public FacturaServicio(FacturasDbContext context) : base(context)
		{ }
	}
}
