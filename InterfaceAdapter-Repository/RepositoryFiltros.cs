using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AplicationLayer;
using EnterpriseLayer;
using InterfaceAdapter_Darta;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapter_Repository
{
	public class RepositoryFiltros<T> : IRepositoryFiltro<T> where T : class
	{
		private readonly ContabilidadDatabaseContext _dbContext;
		private int _pageSize = 10;

		public RepositoryFiltros( ContabilidadDatabaseContext dbContext )
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<T>> GetDteEmitidosFiltrosAsync(
				Expression<Func<T, bool>>? criteria,
				Expression<Func<T, object>> orderByDescending, 
				int _pageNumber = 1
			)
		{
			int pageNumber = _pageNumber;
			int skipCount = (pageNumber - 1) * _pageSize;

			var consulta = await _dbContext.Set<T>()
				.Where(criteria)
				.OrderByDescending(orderByDescending)
				.Skip(skipCount)
				.Take(_pageSize)
				.ToListAsync();

			Console.WriteLine("consulta GeDteEmitidosFiltroAsync....");
			Console.WriteLine(consulta);

			return consulta;
		}
	}
}
