using System.Linq.Expressions;
using EnterpriseLayer;

namespace AplicationLayer
{
	public interface IRepositoryFiltro<T> where T : class
	{
			Task<IEnumerable<T>> GetDteEmitidosFiltrosAsync(
					Expression<Func<T, bool>>? criteria,
					Expression<Func<T, object>> orderByDescending,
					int _pageNumber= 1
				);

	}
}
