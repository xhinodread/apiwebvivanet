using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseLayer
{
	public class ParametroRangoRemuneracionEntity
	{
		[Key]
		[Column("IdParametroRangoRemuneracion", TypeName = "long")]
		public int? Id { get; set; }
		[Column(TypeName = "money")] public decimal? Desde { get; set; }
		[Column(TypeName = "money")] public decimal? Hasta { get; set; }
		public double? Factor { get; set; }
		[Column(TypeName = "money")] public double? Monto { get; set; }
		[Column(TypeName = "money")] public double? Rebaja { get; set; }
		public DateOnly? FechaVigencia { get; set; }
		public string? CodigoParametro { get; set; }
		public int? Tramo { get; set; }
	}
}
