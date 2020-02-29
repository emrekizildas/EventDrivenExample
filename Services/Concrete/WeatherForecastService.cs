using System;
using System.Collections.Generic;
using System.Linq;
using EventDrivenExample.Events;
using EventDrivenExample.Models;
using EventDrivenExample.Services.Abstract;

namespace EventDrivenExample.Services.Concrete
{
    public class WeatherForecastService : IWeatherForecastService
    {

        public event EventHandler<WeatherForecastEventArgs> OnWeatherTransactionProcessed;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetWeatherForecast(int days)
        {
            var rng = new Random();
            var weatherForecats = Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            
            if (OnWeatherTransactionProcessed != null)
                OnWeatherTransactionProcessed(this, new WeatherForecastEventArgs(days));

            return weatherForecats;
        }
    }
}