using FacturasABM.Core.Entidades;

namespace FacturasABM.Data.Entidades
{
	public class LineaFactura : EntidadBase
	{
		public override int Id { get => base.Id; set => base.Id = value; }
		public decimal Importe { get; set; }
		public decimal IVA { get; set; }

		public int IdFactura { get; set; }
		public Factura Factura { get; set; }

		public LineaFactura()
		{
			Factura = new Factura();
		}
	}
}
