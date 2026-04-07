using DTO.ForecastDtos;

namespace DTO
{
    public class ExternalForecastDto
    {
        public LocationDto Location { get; set; }

        public CurrentDto Current { get; set; }

        public ForecastDto Forecast { get; set; }
    }
}
