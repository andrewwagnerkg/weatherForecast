namespace DTO
{
    public class CurrentLookupDto : BaseLookupDto
    {
        public static CurrentLookupDto Error(string errorMessage) => new CurrentLookupDto
        {
            Status = 500,
            Message = errorMessage
        };

        public string LastUpdated { get; set; }
        public double TemperatureCelsius { get; set; }
        public double FeelsLikeCelsius { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIconUrl { get; set; }
    }
}
