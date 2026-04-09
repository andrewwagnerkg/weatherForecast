using System;

namespace DTO
{
    public class DailyDto
    {
        public DateTime Date { get; set; }
        public double MaxTemperatureCelsius { get; set; }
        public double MinTemperatureCelsius { get; set; }
        public double AvgTemperatureCelsius { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIconUrl { get; set; }
    }
}
