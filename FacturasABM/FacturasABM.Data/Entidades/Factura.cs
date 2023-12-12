using FacturasABM.Core.Constantes;
using FacturasABM.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Data.Entidades
{
	public class Factura : EntidadBase
	{
		[Column("IdFactura")]
		public override int Id { get => base.Id; set => base.Id = value; }
		public string NumFactura { get; set; }
		public decimal ImporteTotal { get; set; }
		public decimal IVATotal { get; set; }		
		
		public EstadoFactura Estado { get; set; }

		public int? IdEmpresa { get; set; }
		public Empresa? Empresa { get; set; }
		public int? IdPersona { get; set; }
		public Persona? Persona { get; set; }		

		public ICollection<LineaFactura> LineasFactura { get; set; }

		public Factura()
		{
			NumFactura = string.Empty;

			LineasFactura = new List<LineaFactura>();
		}
	}
}
