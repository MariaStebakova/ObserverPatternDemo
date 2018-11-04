namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
    }
}