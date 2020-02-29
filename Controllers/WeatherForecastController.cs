using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventDrivenExample.Models;
using EventDrivenExample.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventDrivenExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IAuditService _auditService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService, IAuditService auditService)
        {
            _weatherForecastService = weatherForecastService;
            _auditService = auditService;
            _auditService.Subscribe(_weatherForecastService);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(int days)
        {
            var weatherForecasts = _weatherForecastService.GetWeatherForecast(days);
            return weatherForecasts;
        }
    }
}
