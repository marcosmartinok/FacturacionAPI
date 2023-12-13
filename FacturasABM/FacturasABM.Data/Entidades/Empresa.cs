using FacturasABM.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Data.Entidades
{
	public class Empresa : EntidadBase
	{
		public override int Id { get => base.Id; set => base.Id = value; }
		public string RazonSocial { get; set; }
		public string CIF { get; set; }

		public ICollection<Factura> Facturas { get; set; }

		public Empresa() 
		{
			RazonSocial = string.Empty;
			CIF = string.Empty;

			Facturas = new List<Factura>();
		}
	}

}
