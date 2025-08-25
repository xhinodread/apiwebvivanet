using System.Linq.Expressions;
using EnterpriseLayer;

namespace AplicationLayer
{
	public interface IRepository
	{
		//Task <ParametroRangoRemuneracionEntity> GetByIdAsync(int? anio = null);
		Task<IEnumerable<ParametroRangoRemuneracionEntity>> GetByDateAsync(int? anio = null); // GetAllAsync()
		Task<IEnumerable<ParametroRangoRemuneracionEntity>> GetByMesAsync(string? periodo= null);
		Task<IEnumerable<DocumentoDteEntity>> GetDteEmitidosAsync(int _pageNumber= 1);
		
		//Task AddAsync(ParametroRangoRemuneracionEntity valor);
	}
}
