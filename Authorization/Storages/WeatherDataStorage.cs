using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorization.Models;

namespace Authorization.Storages
{
    public static class WeatherDataStorage
    {
        public static List<DayForecastModel> GetAll()
        {
            var wheathers = new List<DayForecastModel>();
            var random = new Random();

            for (int i = -3; i <= 3; i++)
            {
                var data = new DayForecastModel()
                {
                    Date = DateTime.Now.AddDays(i),
                    MinTemperature = random.Next(-20, 5),
                    MaxTemperature = random.Next(5, 25),
                    Pressure = random.Next(100, 300),
                    WindSpeed = random.Next(0, 20),
                    WindDirection = WindDirection.North,
                    Wheather = WeatherCodes.Snowfall,
                    HourlyForecasts = GetAllHourlyForecasts(),
                };
                wheathers.Add(data);
            }
            return wheathers;
        }
        private static List<HourlyForecastModel> GetAllHourlyForecasts()
        {
            var random = new Random();
            var hourlyForecasts = new List<HourlyForecastModel>();  // список для хранения почасовых прогнозов
            for (int i = 0; i < 24; i++)
            {
                var data = new HourlyForecastModel()  // формирование прогноза для каждого часа
                {
                    TimeSpan = DateTime.Now.Date.AddHours(i).TimeOfDay,
                    Time = DateTime.Now.Date.AddHours(i),
                    ApparentTemperature = random.Next(5, 25),
                    Weather = WeatherCodes.Snowfall,
                    WindDirection = WindDirection.East,
                };
                hourlyForecasts.Add(data);
            }
            return hourlyForecasts;
        }
    }
}
