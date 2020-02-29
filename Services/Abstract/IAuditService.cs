namespace EventDrivenExample.Services.Abstract
{
    public interface IAuditService
    {
        void Subscribe(IWeatherForecastService weatherForecastService);
    }
}