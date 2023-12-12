using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Constantes
{
	public enum EstadoFactura
	{
		Nueva,
		Provisional,
		Definitiva,
		Contabilizada,
		Pagada,
		Cancelada,
		Rechazada
	}
}
