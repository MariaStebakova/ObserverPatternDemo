using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        public List<IObserver<WeatherInfo>> Observers { get; private set; }
        

        public WeatherData()
        {
            Observers = new List<IObserver<WeatherInfo>>();
        }

        public void GenerateInfo()
        {
            Random random = new Random();
            WeatherInfo info;
            while (true)
            {
                Console.WriteLine("---------------------------------------------------\r\n");

                info = new WeatherInfo();

                info.Temperature = random.Next(0, 40);
                info.Humidity = random.Next(0, 100);
                info.Pressure = random.Next(700, 800);

                Notify(this, info);

                Thread.Sleep(5000);
            }
        }

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            foreach (var observer in Observers)
            {
                observer.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
                throw new ArgumentNullException($"{nameof(observer)} can't be equal to null");

            Observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
                throw new ArgumentNullException($"{nameof(observer)} can't be equal to null");

            while (Observers.Remove(observer));
        }
    }
}