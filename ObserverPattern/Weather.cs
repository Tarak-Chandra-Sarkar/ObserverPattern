namespace ObserverPattern
{
    public class Weather
    {
        public double Pressure { get; }
        public double Humidity { get; }
        public double Temperature { get; }

        public Weather(double pressure, double humidity, double temperature)
        {
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
        }
    }
}