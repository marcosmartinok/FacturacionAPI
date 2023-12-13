using FacturasABM.Data.Entidades;
using Microsoft.EntityFrameworkCore;

public class FacturasDbContext : DbContext
{
	public FacturasDbContext(DbContextOptions<FacturasDbContext> options)
		: base(options)
	{
	}

	public DbSet<Persona> Personas { get; set; }
	public DbSet<Empresa> Empresas { get; set; }
	public DbSet<Factura> Facturas { get; set; }
	public DbSet<LineaFactura> LineasFactura { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Configuración para entidad 'Persona'
		builder.Entity<Persona>(entity =>
		{
			entity.ToTable("Persona");
			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id).HasColumnName("IdPersona");
			entity.Property(x => x.Nombre).IsRequired().HasMaxLength(255);
			entity.Property(x => x.Apellido1).HasMaxLength(255);
			entity.Property(x => x.Apellido2).HasMaxLength(255);
			entity.Property(x => x.NIF).IsRequired().HasMaxLength(20);
			entity.HasIndex(x => x.NIF).IsUnique();
		});

		// Configuración para entidad 'Empresa'
		builder.Entity<Empresa>(entity =>
		{
			entity.ToTable("Empresa");
			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id).HasColumnName("IdEmpresa");
			entity.Property(x => x.RazonSocial).IsRequired().HasMaxLength(255);
			entity.HasIndex(x => x.RazonSocial).IsUnique();
			entity.Property(x => x.CIF).IsRequired().HasMaxLength(9);
			entity.HasIndex(x => x.CIF).IsUnique();
		});

		// Configuración para entidad 'Factura'
		builder.Entity<Factura>(entity =>
		{
			entity.ToTable("Factura");
			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id).HasColumnName("IdFactura");
			entity.Property(x => x.NumFactura).IsRequired().HasMaxLength(255);
			entity.HasIndex(x => x.NumFactura).IsUnique();
			entity.Property(x => x.GUIDFactura).IsRequired().HasMaxLength(36);
			entity.HasIndex(x => x.GUIDFactura).IsUnique();
			entity.Property(x => x.ImporteTotal).IsRequired().HasColumnType("DECIMAL(10, 2)");
			entity.Property(x => x.IVATotal).IsRequired().HasColumnType("DECIMAL(5, 2)");
			entity.HasOne(x => x.Empresa).WithMany(x => x.Facturas).HasForeignKey(x => x.IdEmpresa).OnDelete(DeleteBehavior.SetNull);
			entity.HasOne(x => x.Persona).WithMany(x => x.Facturas).HasForeignKey(x => x.IdPersona).OnDelete(DeleteBehavior.SetNull);
		});

		// Configuración para entidad 'LineaFactura'
		builder.Entity<LineaFactura>(entity =>
		{
			entity.ToTable("LineaFactura");
			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id).HasColumnName("IdLineaFactura");
			entity.Property(x => x.Importe).IsRequired().HasColumnType("DECIMAL(10, 2)");
			entity.Property(x => x.IVA).IsRequired().HasColumnType("DECIMAL(5, 2)");
			entity.HasOne<Factura>(x => x.Factura).WithMany(x => x.LineasFactura).HasForeignKey(x => x.IdFactura).OnDelete(DeleteBehavior.Cascade);
		});
	}
}
