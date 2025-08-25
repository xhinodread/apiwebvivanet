using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EnterpriseLayer;

namespace AplicationLayer
{
	public class GetDteEmitidosFiltroUseCase
	{
		private readonly IRepositoryFiltro<DocumentoDteEntity> _dteRepository;

		public GetDteEmitidosFiltroUseCase(IRepositoryFiltro<DocumentoDteEntity> dteRepository)
		{
			_dteRepository = dteRepository;
		}
		public async Task<IEnumerable<DocumentoDteEntity>> ExecuteAsync(
			Dictionary<string, string[]> _diccionario,
			string? estado, 
			int _pageNumber = 1
			)
		//public async Task<IEnumerable<DocumentoDteEntity>> ExecuteAsync(string? estado, int _pageNumber = 1)
		{

			Console.WriteLine("Dictionary....");
			Console.WriteLine(JsonSerializer.Serialize(_diccionario));
			Console.WriteLine((_diccionario.ContainsKey("folio") ? _diccionario["folio"].ToString() : "no existe folio...." ));
			// Console.WriteLine((_diccionario["folio"].ToString() ));
			//Console.WriteLine(_diccionario);
			Console.WriteLine("...............");



			// La lógica para construir el criterio dinámico se encuentra aquí, en el caso de uso.
			Expression<Func<DocumentoDteEntity, bool>> criteria = d => true;

			//if (!string.IsNullOrEmpty(estado))
			//{
			//	criteria = d => d.IdTipoDte == 1;
			//}
			//criteria = d => d.IdTipoDte == 1;
			// criteria = d => d.Folio == 481;

		
			var filtro = new Dictionary<string, string>();
			if (_diccionario.ContainsKey("folio"))
			{
				filtro.Add("folio", (JsonSerializer.Serialize(_diccionario["folio"])).Replace("[", "").Replace("]", "").Replace('"', ' ').Trim());
				criteria = d => d.Folio == int.Parse(filtro["folio"].Replace('"', ' '));
				//Console.WriteLine(filtro["folio"].Length );
			}
			filtro.Add("fechaEmision", "");
			filtro.Add("IdTipoDte", estado);
			Console.WriteLine("...............");


			//Console.WriteLine(filtro["folio"].Replace('"', ' ').Trim() );

			//if (_diccionario.ContainsKey("folio")){
			//	criteria = d => d.Folio == int.Parse(filtro["folio"].Replace('"', ' '));
			//}
			//criteria = d => d.IdTipoDte == int.Parse(filtro["IdTipoDte"]);


			Expression<Func<DocumentoDteEntity, object>> orderBy = d => d.FechaEmision;
			// .OrderByDescending(u => u.FechaEmision)

			return await _dteRepository.GetDteEmitidosFiltrosAsync(criteria, orderBy, _pageNumber);
		}
	}
}
