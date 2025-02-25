using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class DayForecastModel
    {
        public DateTime Date { get; set; }

        public string DayOfWeek { get; set; }

        public float MaxTemperature { get; set; }

        public float MinTemperature { get; set; }

        public float Pressure { get; set; }
        public float WindSpeed { get; set; }
        public WindDirection WindDirection { get; set; }
        public WeatherCodes Wheather { get; set; }
        public string Location { get; set; }

        public List<HourlyForecastModel> HourlyForecasts { get; set; }
    }
}
