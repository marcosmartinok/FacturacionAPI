using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.DTOs
{
	public class PersonaDto
	{
		public string Nombre { get; set; }
		public string Apellido1 { get; set; }
		public string Apellido2 { get; set; }
		public string NIF { get; set; }

		public PersonaDto()
		{
			Nombre = string.Empty;
			Apellido1 = string.Empty;
			Apellido2 = string.Empty;
			NIF = string.Empty;
		}
	}
}
