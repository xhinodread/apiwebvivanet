//using System.Linq;
//using apiwebvivanet.basedatos;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using apiwebvivanet.Dtos;
using apiwebvivanet.Utils;
using AplicationLayer;
using EnterpriseLayer;
using InterfaceAdapter_Darta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

//using Microsoft.IdentityModel.Tokens;

namespace apiwebvivanet.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class ParametrosRemuController : ControllerBase
	{

		private readonly ContabilidadDatabaseContext _dbContext;

		private readonly GetRangoRemuneracionUseCase _getRangoRemuneracionUseCase;

		private readonly GetImpuestoUnicoUseCase _getImpuestoUnicoUseCase;
		//private int valorAnio = DateOnly.FromDateTime(DateTime.Now).Year;

		//private readonly General _general;

		public ParametrosRemuController(
			//General general,
			ContabilidadDatabaseContext dbContext,
			GetRangoRemuneracionUseCase getRangoRemuneracionUseCase,
			GetImpuestoUnicoUseCase getImpuestoUnicoUseCase
			)
        {
			//_general = general;
			_dbContext = dbContext;
			_getRangoRemuneracionUseCase = getRangoRemuneracionUseCase;
			_getImpuestoUnicoUseCase = getImpuestoUnicoUseCase;
		}

		/*****
		public IEnumerable<string> Get()
		{
			yield return "hola";
		}
		*****/

		[HttpPost]
		[Route("updateParametroImpuesto")]
		public async Task<IActionResult> UpdateParametroImpuesto(ImpuestoUnicoDto impuestoUnicoDto)
		{
			Console.WriteLine(impuestoUnicoDto);
			return new OkObjectResult(impuestoUnicoDto);
		}

		[HttpGet]
		[Route("GetByPeriodo")]
		public async Task<IActionResult> GetByPeriodo(string? periodo = null)
		{			
			if (periodo != null && !General.IsValidPeriodoDateFormat(periodo))
			{
				return new BadRequestObjectResult("Formato de periodo inválido...");
			}

			var hostHeader = HttpContext.Request.Headers; // ["Host"].FirstOrDefault();
			Console.WriteLine("Request.Headers");
			//Console.WriteLine(Request.Headers);
			Console.WriteLine(JsonSerializer.Serialize(hostHeader) );
			Console.WriteLine("***************");

			var consulta = _getImpuestoUnicoUseCase.ExecuteAsync(periodo).Result;
			//Console.WriteLine("consulta GetByPeriodo");
			//Console.WriteLine(consulta.First());
			//Console.WriteLine("Periodo");
			//Console.WriteLine(periodo);

			List<ImpuestoUnicoDto> objListaRespuesta = new List<ImpuestoUnicoDto>();

			foreach (var item in consulta)
			{
				var objDto = new ImpuestoUnicoDto()
				{
					Id = item.Id.ToString(),
					Desde = item.Desde.ToString(),
					Hasta = item.Hasta.ToString(),
					Factor = item.Factor.ToString(),
					Monto = item.Monto.ToString(),
					Rebaja = item.Rebaja.ToString(),
					FechaVigencia = item.FechaVigencia.ToString(),
					CodigoParametro = item.CodigoParametro
				};
				objListaRespuesta.Add(objDto);
			}

			//return new OkObjectResult(consulta);
			return new OkObjectResult(objListaRespuesta);

		}

		[HttpGet]
		public async Task<IActionResult> Get(int? anio = null)
		{
			/**** /
			int valorAnio = DateOnly.FromDateTime(DateTime.Now).Year;

			var consultaA = await _dbContext
				.ParametroRangoRemuneracion
				//.Where(u => u.CodigoParametro != null )
				.Where(u => u.CodigoParametro != null 
						&& u.CodigoParametro == "IU"
						&& u.FechaVigencia.Value.Year == (anio == null ? valorAnio : anio)
					  )
				.OrderByDescending(u => u.FechaVigencia)
				.ThenBy(u => u.Desde)
				.ToListAsync();

			Console.WriteLine("consultaA");
			Console.WriteLine(consultaA);

			/ ****/
			//.Take(10)
			//.SelectMany();
			//.FirstOrDefaultAsync();

			//var consultaA = await _dbContext
			//	.ParametroRangoRemuneracion.Where(u => 1 == 1).Take(10).OrderBy(u => u.Id).ToListAsync();

			var consulta = _getRangoRemuneracionUseCase.ExecuteAsync(anio).Result;

			Console.WriteLine("consulta");
			Console.WriteLine(consulta);

			List<ImpuestoUnicoDto> objListaRespuesta = new List<ImpuestoUnicoDto>();

			foreach (var item in consulta)
			{
				var objDto = new ImpuestoUnicoDto()
				{
					Desde = item.Desde.ToString(),
					Hasta = item.Hasta.ToString(),
					Factor = item.Factor.ToString(),
					Monto = item.Monto.ToString(),
					Rebaja = item.Rebaja.ToString(),
					FechaVigencia = item.FechaVigencia.ToString(),
					CodigoParametro = item.CodigoParametro
				};
				objListaRespuesta.Add(objDto);
			}

			//var objRespuesta = new ImpuestoUnicoDto()
			//{
			//	Desde = "0,00",
			//	Hasta = "926734,50",
			//	Factor = "0",
			//	Monto = "10",
			//	Rebaja = "1,0",
			//	FechaVigencia = new DateOnly(2025, 3, 13).ToString(),
			//	CodigoParametro = "IU"
			//};

			//System.Threading.Thread.Sleep(500);

			//return new OkObjectResult("hola");
			return new OkObjectResult(objListaRespuesta);
			//return new OkObjectResult(objRespuesta);
			//return new OkObjectResult(consulta);
			//return new JsonResult(objRespuesta);
		}
	}
}
