using System;
using System.Collections.Generic;
using EventDrivenExample.Events;
using EventDrivenExample.Models;

namespace EventDrivenExample.Services.Abstract
{
    public interface IWeatherForecastService
    {
        event EventHandler<WeatherForecastEventArgs> OnWeatherTransactionProcessed;
        IEnumerable<WeatherForecast> GetWeatherForecast(int days);
    }
}