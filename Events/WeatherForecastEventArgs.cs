using System;

namespace EventDrivenExample.Events
{
    public class WeatherForecastEventArgs : EventArgs
    {
        public int Day { get; set; }

        public WeatherForecastEventArgs(int day)
        {
            Day = day;
        }
    }
}