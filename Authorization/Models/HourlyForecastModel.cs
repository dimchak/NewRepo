using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class HourlyForecastModel
    {
        public TimeSpan TimeSpan { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float SurfacePressure { get; set; }
        public float WindSpeed { get; set; }
        public WindDirection WindDirection { get; set; }
        public WeatherCodes Weather { get; set; }
    }
}
