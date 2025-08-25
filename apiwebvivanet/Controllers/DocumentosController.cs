using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using AplicationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace apiwebvivanet.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DocumentosController: ControllerBase
	{

		private static GetDteEmitidosUseCase _getDteEmitidosUseCase;
		private static GetDteEmitidosFiltroUseCase _getDteEmitidosUCase;

        public DocumentosController(
			GetDteEmitidosUseCase getDteEmitidosUseCase,
			GetDteEmitidosFiltroUseCase getDteEmitidosUCase
			)
        {
			_getDteEmitidosUseCase = getDteEmitidosUseCase;
			_getDteEmitidosUCase = getDteEmitidosUCase;
		}

        [HttpGet]
		[Route("documentos_recibidos")]
		public async Task<IActionResult> GetDteEmitidos(int pageNumber = 1)
		{
			Console.WriteLine("... getRequest ...");

			var registroRequest = Request.Query;
			var filtro = registroRequest.Where(valor => valor.Key != "pageNumber");

			var queryDictionary = registroRequest.ToDictionary(
				   pair => pair.Key,
				   pair => pair.Value.ToArray()
			   );

			Console.WriteLine("queryDictionary  request...");
			Console.WriteLine((queryDictionary));
			Console.WriteLine(JsonSerializer.Serialize(queryDictionary));

			//var folioFiltro = JsonSerializer.Serialize(registroRequest);
			//Console.WriteLine("folioFiltro  request...");
			//Console.WriteLine(folioFiltro);

			//var folioFiltroQuery = registroRequest["folio"];
			
			//var folioValor = "";

			//Console.WriteLine(JsonSerializer.Serialize(registroRequest));
			//Console.WriteLine(folioFiltroQuery);
			//Console.WriteLine(folioFiltroQuery.IsNullOrEmpty() );
			//Console.WriteLine((folioFiltroQuery).GetType() );

			//if (registroRequest.TryGetValue("folio", out var value))
			//{
			//	Console.WriteLine(value);
			//	folioValor = value;
			//}
			//Console.WriteLine(".............");
			//Console.WriteLine(JsonSerializer.Serialize(folioValor));
			//Console.WriteLine("filtro");
			Console.WriteLine(".............");

				//GetRequestFiltroDte getRequestFiltroDte = new GetRequestFiltroDte()
				//{
				//	idEmpresa=0,
				//	folio = folioValor
				//};

			var listaF = await _getDteEmitidosUCase.ExecuteAsync(queryDictionary, "1", pageNumber); // 19170668

			var lista = await _getDteEmitidosUseCase.ExecuteAsync(pageNumber);

			//Console.WriteLine("lista dte emitidos....");
			//Console.WriteLine(lista);
			//Console.WriteLine(listaF);

			//return new OkObjectResult({ valor:"fff"});
			return StatusCode(StatusCodes.Status200OK, new { 
				valor = true,
				listado = lista,
				listadoF = listaF,
				filtro = filtro
			});

		}
	}

	public class GetRequestFiltroDte
	{
		public int? idEmpresa { get; set; }
		public string? folio { get; set; }
		//public string fechaEmision { get; set; }
		//public string BackEnd { get; set; }
	}
}
