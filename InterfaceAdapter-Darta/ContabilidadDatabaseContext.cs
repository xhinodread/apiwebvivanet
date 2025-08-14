using System.Collections.Generic;
using EnterpriseLayer;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapter_Darta
{
	public class ContabilidadDatabaseContext : DbContext
	{
		public ContabilidadDatabaseContext(DbContextOptions<ContabilidadDatabaseContext> options) : base(options) {

		}

		public DbSet<ParametroRangoRemuneracionEntity> ParametroRangoRemuneracion { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	//base.OnModelCreating(modelBuilder);
		//	//modelBuilder.Entity<ParametroRangoRemuneracionEntity>().ToTable("ParametroRangoRemuneracion");
		//}

	}
}
