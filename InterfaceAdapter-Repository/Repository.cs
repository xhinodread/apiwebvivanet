
using AplicationLayer;
using EnterpriseLayer;
using InterfaceAdapter_Darta;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterfaceAdapter_Repository
{
	public class Repository : IRepository
	{
		private readonly ContabilidadDatabaseContext _dbContext;

        public Repository(ContabilidadDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

		public async Task<IEnumerable<ParametroRangoRemuneracionEntity>> GetByDateAsync(int? anio = null)
		{
			int valorAnio = DateOnly.FromDateTime(DateTime.Now).Year;

			var consulta = await _dbContext
				.ParametroRangoRemuneracion
				.Where(u => u.CodigoParametro != null
						&& u.CodigoParametro == "IU"
						&& u.FechaVigencia.Value.Year == (anio == null ? valorAnio : anio)
					  )
				.OrderByDescending(u => u.FechaVigencia).ThenBy(u => u.Desde)
				.ToListAsync();

			Console.WriteLine( "consulta");	
			Console.WriteLine( consulta );

			return consulta;
		}

		public async Task<IEnumerable<ParametroRangoRemuneracionEntity>> GetByMesAsync(string? periodo = null)
		{
			//List<ParametroRangoRemuneracionEntity> consulta = new List<ParametroRangoRemuneracionEntity>();

			//consulta.Add(
			//	new ParametroRangoRemuneracionEntity()
			//	{
			//		Id = 1
			//	});
			
			//consulta.Add(
			//	new ParametroRangoRemuneracionEntity()
			//	{
			//		Id = 2
			//	});

			int valorAnio = DateOnly.FromDateTime(DateTime.Now).Year;
			int valorMes = DateOnly.FromDateTime(DateTime.Now).Month;

			int periodoAnio = periodo == null ? valorAnio : int.Parse(periodo.Split("/")[1]);
			var periodoMes = periodo == null ? valorMes : int.Parse(periodo.Split("/")[0]);

			//Console.Write("periodo seleccionado");
			//Console.Write(periodo);

			var consulta = await _dbContext
				.ParametroRangoRemuneracion
				.Where(u => u.CodigoParametro != null
				&& u.CodigoParametro == "IU"
						&& u.FechaVigencia.Value.Year == periodoAnio
						&& u.FechaVigencia.Value.Month == periodoMes
					  )
				.OrderByDescending(u => u.FechaVigencia).ThenBy(u => u.Desde)
				.ToListAsync();

			return consulta;

		}
	}
}
