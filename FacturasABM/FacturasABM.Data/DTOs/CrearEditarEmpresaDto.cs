using FacturasABM.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.DTOs
{
	public class CrearEditarEmpresaDto
	{
		public string RazonSocial { get; set; }
		public string CIF { get; set; }

		public CrearEditarEmpresaDto()
		{
			RazonSocial = string.Empty;
			CIF = string.Empty;
		}
	}
}
