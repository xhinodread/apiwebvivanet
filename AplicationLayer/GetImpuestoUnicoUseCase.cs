using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseLayer;

namespace AplicationLayer
{
	public class GetImpuestoUnicoUseCase
	{
		private readonly IRepository _rangoRemuneracionRepository;


        public GetImpuestoUnicoUseCase(IRepository rangoRemuneracionRepository)
        {
            _rangoRemuneracionRepository = rangoRemuneracionRepository;
        }

		public async Task<IEnumerable<ParametroRangoRemuneracionEntity>> ExecuteAsync(string? periodo = null)
		{
			return await _rangoRemuneracionRepository.GetByMesAsync(periodo);
		}
	}
}
