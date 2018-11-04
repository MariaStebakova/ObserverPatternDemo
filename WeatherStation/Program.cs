using System;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionsReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            weatherData.Register(statisticReport);
            weatherData.Register(currentConditionsReport);

            WeatherInfo currentWeatherInfo = new WeatherInfo(20, 1000, 50);
            weatherData.Notify(weatherData, currentWeatherInfo);

            Console.WriteLine(currentConditionsReport);
            Console.WriteLine();

            WeatherInfo[] statisticInfo =
            {
                new WeatherInfo(23, 1000, 55),
                new WeatherInfo(22, 1001, 50)
            };

            foreach (var info in statisticInfo)
            {
                weatherData.Notify(weatherData, info);
            }

            Console.WriteLine(currentConditionsReport);
            Console.WriteLine();

            string[] statisticReportInfo = statisticReport.GetStatisticReport();

            foreach (var info in statisticReportInfo)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine();

            weatherData.Unregister(currentConditionsReport);
            WeatherInfo infoAfterUnregistering = new WeatherInfo(15, 1000, 60);
            weatherData.Notify(weatherData, infoAfterUnregistering);

            Console.WriteLine("*** Real current conditions: 15, 1000, 60 ***");
            Console.WriteLine(currentConditionsReport);

            Console.Read();
        }
    }
}
