using System;
using EventDrivenExample.Events;
using EventDrivenExample.Services.Abstract;

namespace EventDrivenExample.Services.Concrete
{
    public class AuditService : IAuditService
    {
        public void Subscribe(IWeatherForecastService weatherForecastService)
        {
            weatherForecastService.OnWeatherTransactionProcessed += WriteAuditLog;
        }

        private void WriteAuditLog(object sender, WeatherForecastEventArgs e)
        {
            Console.WriteLine($"AUDIT LOG: {e.Day} günlük hava durumu sorgulandı.");
        }
    }
}
