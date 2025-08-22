using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseLayer;

namespace AplicationLayer
{
	public class GetDteEmitidosUseCase
	{

		private readonly IRepository _dteRepository;

        public GetDteEmitidosUseCase(IRepository dteRepository)
        {
            _dteRepository = dteRepository;            
        }
		public async Task<IEnumerable<DocumentoDteEntity>> ExecuteAsync(int _pageNumber = 1)
		{
			return await _dteRepository.GetDteEmitidosAsync(_pageNumber);
		}

	}
}
