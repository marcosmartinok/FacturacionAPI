using FacturasABM.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Data.Entidades
{
	public class LineaFactura : EntidadBase
	{
		[Column("IdLineaFactura")]
		public override int Id { get => base.Id; set => base.Id = value; }
		public decimal Importe { get; set; }
		public int IVA { get; set; }

		public int IdFactura { get; set; }
		public Factura Factura { get; set; }		

		public LineaFactura()
		{
			Factura = new Factura();
		}
	}
}
