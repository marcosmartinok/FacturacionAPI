using FacturasABM.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Data.Entidades
{
	public class Persona : EntidadBase
	{
		[Column("IdPersona")]
		public override int Id { get => base.Id; set => base.Id = value; }
		public string Nombre { get; set; }
		public string Apellido1 { get; set; }
		public string Apellido2 { get; set; }
		public string NIF { get; set; }

		public ICollection<Factura> Facturas { get; set; }

		public Persona() 
		{ 
			Nombre = string.Empty;
			Apellido1 = string.Empty;
			Apellido2 = string.Empty;
			NIF = string.Empty;

			Facturas = new List<Factura>();
		}
	}

}
