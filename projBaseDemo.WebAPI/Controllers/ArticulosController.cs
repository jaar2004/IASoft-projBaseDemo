// IAR jue 30MAY2024

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projBaseDemo.Domain.Entities;

namespace projBaseDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ApiControllerBase
    {

        private readonly IMediator _mediator; // IAR lun 01JUL2024
        private readonly ILogger<ArticulosController> _logger;

        //public ArticulosController(ILogger<ArticulosController> logger)
        public ArticulosController(ILogger<ArticulosController> logger, IMediator mediator) // IAR lun 01JUL2024
        {
            _logger = logger;
            _mediator = mediator; // IAR lun 01JUL2024
        }

        [HttpGet(Name = "GetArticulos")]
        public ActionResult<Articulo> Get()
        {
            _logger.LogDebug("Inside GetArticulos endpoint");

            var response = new Articulo
            {
                ArticuloId = 1,
                Itemno = "ABC",
                Descripcion = "Articulo test",
                IdCategoria = "XYZ",
                Almacen = "Alm1",
                Status = true,
                Vigente = true,
                FechaAlta = DateTime.Now,
                FechaMod = DateTime.Now,
                IdUsuario = 1
            };

            _logger.LogDebug($"The response for the GetArticulos is {JsonConvert.SerializeObject(response)}");
            
            return Ok(response);

        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{

        //    _logger.LogDebug("Inside GetWeatherForecast endpoint");
        //    var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();

        //    _logger.LogDebug($"The response for the get weather forecast is {JsonConvert.SerializeObject(response)}");

        //    return response;

        //    // Comenté esta línea. IAr lun 18SEP2023
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = Random.Shared.Next(-20, 55),
        //    //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();

        //}


    }
}
