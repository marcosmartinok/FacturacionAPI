using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Entidades
{
	public abstract class EntidadBase
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public virtual int Id { get; set; }
	}
}
