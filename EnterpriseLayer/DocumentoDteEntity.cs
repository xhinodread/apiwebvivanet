using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayer
{
	[Table("DteCabecera")]
	public class DocumentoDteEntity
	{
		[Key]
		[Column("IdDteCabecera", TypeName = "long")]
		public long? Id { get; set; }
		[Column(TypeName = "money")] public decimal? MontoNeto { get; set; }
		public int? IdTipoDte { get; set; }
		public long? IdEmpresa { get; set; }
		public long? Folio { get; set; }		
		public DateOnly? FechaEmision { get; set; }
		public DateOnly? FechaVencimiento { get; set; }
		
		            
	}
}
