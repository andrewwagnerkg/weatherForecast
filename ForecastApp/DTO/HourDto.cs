using System;

namespace DTO
{
    public class HourDto
    {
        public DateTime Date { get; set; }
        public double TemperatureCelsius { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIconUrl { get; set; }
    }
}
