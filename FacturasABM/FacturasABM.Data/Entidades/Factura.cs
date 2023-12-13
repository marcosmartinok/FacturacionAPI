using FacturasABM.Core.Constantes;
using FacturasABM.Core.Entidades;

namespace FacturasABM.Data.Entidades
{
	public class Factura : EntidadBase
	{
		public override int Id { get => base.Id; set => base.Id = value; }
		public string GUIDFactura { get; set; }
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
			GUIDFactura = string.Empty;

			LineasFactura = new List<LineaFactura>();
		}
	}
}
