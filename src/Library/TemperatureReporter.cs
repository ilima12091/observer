using System;

namespace Observer
{
    public class TemperatureReporter : IObserver
    {
        private bool first;
        private Temperature last;
        private IObservable provider;

        public void StartReporting(IObservable provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature temperature)
        {
            Console.WriteLine($"The temperature is {temperature.Degrees}°C at {temperature.Date:g}");
            if (first)
            {
                last = temperature;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {temperature.Degrees - last.Degrees}° in " +
                    $"{temperature.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}