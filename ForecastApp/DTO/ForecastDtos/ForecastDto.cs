using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTO.ForecastDtos
{
    public class ForecastDto
    {
        [JsonProperty("forecastday")]
        public List<ForecastDayDto> ForecastDays { get; set; }
    }
}
