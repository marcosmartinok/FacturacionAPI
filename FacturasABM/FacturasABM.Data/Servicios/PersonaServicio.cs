using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Servicios
{
	public class PersonaServicio : ServicioBase<Persona>
	{
		public PersonaServicio(FacturasDbContext context) : base(context)
		{ }
	}
}
