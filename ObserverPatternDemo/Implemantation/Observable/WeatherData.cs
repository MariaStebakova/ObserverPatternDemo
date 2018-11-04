using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        public List<IObserver<WeatherInfo>> Observers { get; private set; }

        public WeatherData()
        {
            Observers = new List<IObserver<WeatherInfo>>();
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

            while (Observers.Remove(observer)) ;
        }
    }
}