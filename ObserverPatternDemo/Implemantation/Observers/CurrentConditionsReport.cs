using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo currentConditions;

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            currentConditions = info;

            Console.WriteLine("Current Conditions Report:");
            Console.WriteLine(this.ToString());
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Current temperature: {currentConditions.Temperature}, humidity: {currentConditions.Humidity}, " +
                   $"pressure: {currentConditions.Pressure}";
        }
    }
}