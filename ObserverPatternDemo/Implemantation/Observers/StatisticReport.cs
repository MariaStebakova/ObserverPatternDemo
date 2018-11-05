using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> statisticInfo;

        public StatisticReport()
        {
            statisticInfo = new List<WeatherInfo>();
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (info == null)
                throw new ArgumentNullException($"{nameof(info)} can't be equal to null");

            statisticInfo.Add(info);

            Console.WriteLine("Statistic Report:");
            foreach (var statisticInfo in GetStatisticReport())
            {
                Console.WriteLine(statisticInfo);
            }
            Console.WriteLine();
            
        }

        public string[] GetStatisticReport()
        {
            string[] report = new string[statisticInfo.Count];

            for (int i = 0; i < statisticInfo.Count; i++)
            {
                report[i] = $"Temperature: {statisticInfo[i].Temperature}, humidity: {statisticInfo[i].Humidity}, " +
                            $"pressure: {statisticInfo[i].Pressure}";
            }

            return report;
        }
    }
}
