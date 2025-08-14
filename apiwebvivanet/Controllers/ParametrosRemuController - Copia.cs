using System.Linq;
using apiwebvivanet.basedatos;
using apiwebvivanet.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace apiwebvivanet.Controllers
{
	/*******
	[ApiController]
	[Route("[controller]")]

	public class ParametrosRemuController : ControllerBase
	{

		private readonly ContabilidadDatabaseContext _dbContext;

		//private int valorAnio = DateOnly.FromDateTime(DateTime.Now).Year;

		public ParametrosRemuController(ContabilidadDatabaseContext dbContext)
        {
			_dbContext = dbContext;
        }

        /*****
		public IEnumerable<string> Get()
		{
			yield return "hola";
		}
		***** /

        [HttpGet]
		public async Task<IActionResult> Get(int? anio = null)
		{
			int valorAnio = DateOnly.FromDateTime(DateTime.Now).Year;

			var consulta = await _dbContext
				.ParametroRangoRemuneracion
				//.Where(u => u.CodigoParametro != null )
				.Where(u => u.CodigoParametro != null 
						&& u.CodigoParametro == "IU"
						&& u.FechaVigencia.Value.Year == (anio == null ? valorAnio : anio)
					  )
				.OrderByDescending(u => u.FechaVigencia)
				.ThenBy(u => u.Desde)
				.ToListAsync();

			//.Take(10)
			//.SelectMany();
			//.FirstOrDefaultAsync();

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
					FechaVigencia = item.FechaVigencia.ToString() ,
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
			//	Rebaja= "1,0",
			//	FechaVigencia = new DateOnly(2025, 3, 13).ToString(),
			//	CodigoParametro ="IU"
			//};

			//return new OkObjectResult("hola");
			return new OkObjectResult(objListaRespuesta);
			//return new JsonResult(objRespuesta);
		}
	}
	******/
}
