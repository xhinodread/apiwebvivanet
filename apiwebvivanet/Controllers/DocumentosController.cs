using AplicationLayer;
using Microsoft.AspNetCore.Mvc;

namespace apiwebvivanet.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DocumentosController: ControllerBase
	{

		private static GetDteEmitidosUseCase _getDteEmitidosUseCase;

        public DocumentosController(GetDteEmitidosUseCase getDteEmitidosUseCase)
        {
			_getDteEmitidosUseCase = getDteEmitidosUseCase;
		}

        [HttpGet]
		[Route("documentos_recibidos")]
		public async Task<IActionResult> GetDteEmitidos(int pageNumber = 1)
		{
			var lista = await _getDteEmitidosUseCase.ExecuteAsync(pageNumber);

			Console.WriteLine("lista dte emitidos....");
			Console.WriteLine(lista);

			//return new OkObjectResult({ valor:"fff"});
			return StatusCode(StatusCodes.Status200OK, new { valor = true, listado = lista });

		}


	}
}
