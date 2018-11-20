using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class WeatherSupplier : IObservable<Weather>
    {
        private readonly List<IObserver<Weather>> _observers;

        private List<Weather> Screens { get; }
        private List<Weather> GetScreens()
        {
            return Screens;
        }

        public WeatherSupplier()
        {
            _observers = new List<IObserver<Weather>>();
            Screens = new List<Weather>();
        }

        public IDisposable Subscribe(IObserver<Weather> observer)
        {
            if (! _observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var weather in GetScreens())
                {
                    observer.OnNext(weather);
                }
            }

            return new Unsubscriber<Weather>(_observers, observer);
        }

        public void WeatherConditions(double pres=0, double humd=0, double temp=0)
        {
            var weatherConditions = new Weather(pres, humd, temp);
            foreach (var observer in _observers)
            {
                observer.OnNext(weatherConditions);
            }
        }
    }
}