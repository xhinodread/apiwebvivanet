using EnterpriseLayer;

namespace AplicationLayer
{
	public interface IRepository
	{
		//Task <ParametroRangoRemuneracionEntity> GetByIdAsync(int? anio = null);
		Task<IEnumerable<ParametroRangoRemuneracionEntity>> GetByDateAsync(int? anio = null); // GetAllAsync()
		Task<IEnumerable<ParametroRangoRemuneracionEntity>> GetByMesAsync(string? periodo= null);

		//Task AddAsync(ParametroRangoRemuneracionEntity valor);
	}
}
