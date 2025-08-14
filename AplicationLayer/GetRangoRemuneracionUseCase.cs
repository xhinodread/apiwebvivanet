using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseLayer;

namespace AplicationLayer
{
	public class GetRangoRemuneracionUseCase
	{
		private readonly IRepository _rangoRemuneracionRepository;

        public GetRangoRemuneracionUseCase(IRepository rangoRemuneracionRepository)
        {
			_rangoRemuneracionRepository = rangoRemuneracionRepository;
		}

		public async Task<IEnumerable<ParametroRangoRemuneracionEntity>> ExecuteAsync(int? anio = null)
		{
			return await _rangoRemuneracionRepository.GetByDateAsync(anio);
		}

    }
}
