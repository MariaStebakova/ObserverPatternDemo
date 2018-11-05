using System;
using System.Threading;
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
            var currentConditionsReport1 = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            weatherData.Register(statisticReport);
            weatherData.Register(currentConditionsReport);
            weatherData.Register(currentConditionsReport1);

            Thread weatherStationThread = new Thread(weatherData.GenerateInfo);
            weatherStationThread.Start();

            Thread.Sleep(10000);
            weatherData.Unregister(currentConditionsReport);
        }
    }
}
