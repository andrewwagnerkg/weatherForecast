namespace DTO
{
    public class ForecastDto
    {
        public CurrentLookupDto Current { get; set; }
        public HourlyLookupDto Hourly { get; set; }
        public DailyLookupDto Daily { get; set; }
    }
}
