using FacturasABM.Core.Constantes;
using FacturasABM.Core.DTOs;
using FacturasABM.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasABM.Core.Servicios
{
	public class FacturaServicio : ServicioBase<Factura>
	{
		public FacturaServicio(FacturasDbContext context) : base(context)
		{ }

		public async Task<IEnumerable<Factura>> GetFacturasAsync(FiltrosFacturaDto filtros)
		{
			try
			{
				// Utiliza filtros para limitar los resultados según los criterios especificados en el DTO de filtros.
				var facturas = await _context.Facturas
					.Where(x => (filtros.IdFactura == null || x.Id == filtros.IdFactura) &&
								(string.IsNullOrEmpty(filtros.GUIDFactura) || x.GUIDFactura == filtros.GUIDFactura) &&
								(string.IsNullOrEmpty(filtros.NumFactura) || x.NumFactura == filtros.NumFactura) &&
								(filtros.Estado == null || x.Estado == filtros.Estado) &&
								(filtros.IdEmpresa == null || x.IdEmpresa == filtros.IdEmpresa) &&
								(filtros.IdPersona == null || x.IdPersona == filtros.IdPersona))
					.Include(x => x.LineasFactura)
					.ToListAsync();

				return facturas;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		public async Task<Factura> CrearFacturaAsync(CrearFacturaDto input)
		{
			try
			{
				// Valida que se cumplan los requisitos de creación.
				var factura = await ValidarInput(input);

				AsignarLineasYCalcularTotales(input, factura);		
				
				await base.AddAsync(factura);
				await _context.SaveChangesAsync();

				return factura;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}			
		}
			
		private async Task<Factura> ValidarInput(CrearFacturaDto input)
		{
			try
			{
				// Crear una nueva instancia de Factura con los datos del DTO de entrada.
				Factura facturaNueva = new Factura()
				{
					GUIDFactura = input.GUIDFactura,
					NumFactura = input.NumFactura,
					ImporteTotal = 0,
					IVATotal = 0,
					Estado = input.Estado,
					IdEmpresa = null,
					IdPersona = null
				};

				// Validar que la factura pertenezca a una empresa o a una persona, pero no a ambas.
				if (input.IdEmpresa != null && input.IdPersona != null || input.IdEmpresa != null && input.PersonaNueva != null)
				{
					throw new Exception("La factura debe pertenecer a una Persona o a una Empresa, pero no a ambas.");
				}

				// Verificar si falta información tanto de empresa como de persona.
				if (input.IdEmpresa == null && input.IdPersona == null && input.PersonaNueva == null)
				{
					throw new Exception("La factura debe pertenecer a una Persona o a una Empresa");
				}

				// Si se proporciona un Id de Empresa, verificar que la empresa exista.
				if (input.IdEmpresa != null)
				{
					var empresa = await _context.Empresas.FindAsync(input.IdEmpresa);

					if (empresa == null)
					{
						throw new Exception($"La empresa indicada con ID {input.IdEmpresa} no existe.");
					}

					facturaNueva.IdEmpresa = empresa.Id;

					return facturaNueva;
				}

				// Si no se proporciona un Id de Persona, crear una nueva Persona.
				if (input.IdPersona == null)
				{
					var personaNueva = new Persona()
					{
						Nombre = input.PersonaNueva.Nombre,
						Apellido1 = input.PersonaNueva.Apellido1,
						Apellido2 = input.PersonaNueva.Apellido2,
						NIF = input.PersonaNueva.NIF
					};

					facturaNueva.Persona = personaNueva;

					return facturaNueva;
				}

				// Verificar que la empresa exista.
				var persona = await _context.Personas.FindAsync(input.IdPersona);

				if (persona == null)
				{
					throw new Exception($"La Persona indicada con ID {input.IdPersona} no existe.");
				}

				facturaNueva.IdPersona = input.IdPersona;

				return facturaNueva;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		private void AsignarLineasYCalcularTotales(CrearFacturaDto input, Factura factura)
		{
			try
			{
				if (input.LineasFactura.Count == 0)
				{
					throw new Exception("Una factura debe contener al menos una línea.");
				}

				decimal importeTotal = 0;
				decimal IVATotal = 0;

				foreach (var linea in input.LineasFactura)
				{
					// Agrega cada linea recibida a la factura.
					factura.LineasFactura.Add(new LineaFactura()
					{
						Importe = linea.Importe,
						IVA = linea.IVA
					});

					// Suma los importes e IVA de cada línea de la factura al total.
					importeTotal += linea.Importe;
					IVATotal += linea.Importe * linea.IVA;
				}

				factura.ImporteTotal = importeTotal;
				factura.IVATotal = IVATotal;
			}
			catch (Exception ex)
			{
				throw new Exception (ex.Message, ex);
			}
		}

		public override async Task UpdateAsync(Factura facturaEditada)
		{
			try
			{
				var factura = await base.GetByIdAsync(facturaEditada.Id);

				// Solamente permite modificar el estado de la factura
				factura.Estado = facturaEditada.Estado;

				_context.Facturas.Update(factura);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
	}
}

